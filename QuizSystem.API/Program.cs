using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuizSystem.Repository.DataBase;
using Framework.Repository;
using QuizSystem.Domain.Repository;
using OnlineQuiz.Repository;
using QuizSystem.Service;
using QuizSystem.Domain.Models;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<QuizSystemContext>(option
    => option.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));

builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<IStudentRepository,StudentRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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
