using AtletaApi.EndPoints;
using AtletaApi.Models;
using Aula10;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AtletaContext>();

builder.Services.AddCors();

builder.Services.AddSingleton<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/* app.MapGet("/", () => "Olá Mundo!");

app.MapGet("/teste", () => "1, 2, 3, testando..."); */

app.AdicionarAtletaEndPoints();
app.AdicionarUsuarioEndPoints();

app.UseCors(builder => builder
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader()
);

app.Run();
