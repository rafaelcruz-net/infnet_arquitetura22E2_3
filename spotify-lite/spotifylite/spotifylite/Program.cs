using Microsoft.EntityFrameworkCore;
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

builder.Services.RegisterRepository(builder.Configuration.GetConnectionString("SpotifyDB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
