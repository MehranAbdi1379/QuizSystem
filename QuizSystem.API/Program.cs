using Microsoft.EntityFrameworkCore;
using QuizSystem.Repository.DataBase;
using QuizSystem.API.Extensions;
using Serilog;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using QuizSystem.Domain.Models;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();

builder.AddDataBaseContext();

builder.AddCors();

builder.AddAuthenticationAndAuthorization();

builder.AddDIForRepositoryClasses();
builder.AddDIForServiceClasses();

builder.Services.SeedData();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger();

var app = builder.Build();

//TODO: Add migrate async


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
