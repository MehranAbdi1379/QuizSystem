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
