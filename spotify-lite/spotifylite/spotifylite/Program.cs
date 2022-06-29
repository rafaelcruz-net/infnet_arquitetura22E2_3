using IdentityModel;
using IdentityServer4.AccessTokenValidation;
using Microsoft.EntityFrameworkCore;
using SpotifyLite.Application;
using SpotifyLite.Domain.Album.Repository;
using SpotifyLite.Domain.User.Repository;
using SpotifyLite.Repository;
using SpotifyLite.Repository.Context;
using SpotifyLite.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
       .RegisterApplication(builder.Configuration.GetConnectionString("SpotifyDB"));

//builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
//                .AddJwtBearer(c =>
//                {
//                    c.TokenValidationParameters.ValidateIssuer = true;
//                    c.TokenValidationParameters.ValidIssuer = "https://localhost:5001";
//                    c.TokenValidationParameters.ValidateIssuerSigningKey = false;
//                    c.TokenValidationParameters.ValidateAudience = false;
//                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
