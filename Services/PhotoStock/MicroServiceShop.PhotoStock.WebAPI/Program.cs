using CloudinaryDotNet;
using MassTransit;
using MicroServiceShop.PhotoStock.WebAPI.Consumers;
using MicroServiceShop.PhotoStock.WebAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(MicroServiceShop.Logging.Logging.ConfigureSerilog());

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicroServiceShop.PhotoStock.WebAPI", Version = "v1" });

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
    options.Audience = "resource_photo";
    options.RequireHttpsMetadata = false;
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

builder.Services.AddScoped<Cloudinary>(provider =>
{
    var account = new Account(
                builder.Configuration["CloudinarySettings:CloudName"],
                builder.Configuration["CloudinarySettings:ApiKey"],
                builder.Configuration["CloudinarySettings:ApiSecret"]);
    return new Cloudinary(account);
});

builder.Services.AddScoped<UploadPhotoConsumer>();

builder.Services.AddMassTransit(x =>
{
    // Consumer'ý ekleyin
    x.AddConsumer<UploadPhotoConsumer>();

    // RequestClient'ý tanýmlayýn
    x.AddRequestClient<UploadPhotoMessage>();

    // RabbitMQ ayarlarý
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMQUrl"], "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });

        cfg.ReceiveEndpoint("upload-photo-queue", e =>
        {
            e.ConfigureConsumer<UploadPhotoConsumer>(context);
        });
    });
});


var app = builder.Build();


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
