using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuizSystem.Repository.DataBase;
using Framework.Repository;
using QuizSystem.Domain.Repository;
using QuizSystem.Service;
using QuizSystem.Domain.Models;
using QuizSystem.API.Extensions;
using Microsoft.AspNetCore.Builder;
using AutoMapper;
using Serilog;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<QuizSystemContext>(option
    => option.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));

builder.Services.AddCors(options =>
{
    var frontendURL = builder.Configuration.GetValue<string>("frontend_url");

    options.AddDefaultPolicy(builder =>
    builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Seq("http://localhost:5341")
    .CreateLogger();

builder.AddDIForRepositoryClasses();
builder.AddDIForServiceClasses();
builder.Services.AddScoped<IAuthManager, AuthManager>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwagger();

var app = builder.Build();

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
