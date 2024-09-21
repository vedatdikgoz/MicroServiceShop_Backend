using MicroServiceShop.Order.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MicroServiceShop.Order.Application.Services;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Serilog;
using MicroServiceShop.Order.Application.Handlers.OrderHandlers;
using MicroServiceShop.Core.Services;
using MassTransit;
using MicroServiceShop.Order.Application.Consumers;




var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(MicroServiceShop.Logging.Logging.ConfigureSerilog());

builder.Services.AddApplicationService(builder.Configuration);


builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateOrderCommandHandler).Assembly));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicroServiceShop.Order.WebAPI", Version = "v1" });

    // Authorization Header için JWT Bearer yapýlandýrmasý
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});

builder.Services.AddAuthentication().AddJwtBearer("GatewayAuthenticationScheme", options =>
{
    options.Authority = builder.Configuration["IdentityServerURL"];
    options.Audience = "resource_order";
    options.RequireHttpsMetadata = false;
});

builder.Services.AddDbContext<OrderContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), configure =>
    {
        configure.MigrationsAssembly("MicroServiceShop.Order.Infrastructure");
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
    builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials()
               .SetIsOriginAllowed(host => true);
    });
});

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreateOrderMessageCommandConsumer>();
    // Default Port : 5672
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMQUrl"], "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });

        cfg.ReceiveEndpoint("create-order-service", e =>
        {
            e.ConfigureConsumer<CreateOrderMessageCommandConsumer>(context);
        });
    });
});


var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var serviceProvider = scope.ServiceProvider;
//    var orderContext = serviceProvider.GetRequiredService<OrderContext>();
//    orderContext.Database.Migrate();
//}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
