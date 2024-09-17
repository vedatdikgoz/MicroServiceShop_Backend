using Duende.IdentityServer.Models;
using MicroServiceShop.IdentityServer.Models;
using MicroServiceShop.IdentityServer6;
using MicroServiceShop.IdentityServer6.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalApiAuthentication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
    builder =>
    {
        builder.AllowAnyOrigin().WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;


    options.EmitStaticAudienceClaim = true;
})
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    .AddAspNetIdentity<ApplicationUser>()
    .AddDeveloperSigningCredential();


var app = builder.Build();

app.UseCors("CorsPolicy");
app.UseIdentityServer();
app.MapGet("/", () => "IdentityServer 6 çalýþýyor!");

app.Run();
