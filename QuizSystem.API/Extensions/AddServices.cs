﻿using OnlineQuiz.Repository;
using QuizSystem.Domain.Repository;
using QuizSystem.Service;

namespace QuizSystem.API.Extensions
{
    public static class AddServices
    {
        public static void AddDIForServiceClasses(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IProfessorService, ProfessorService>();
        }

        public static void AddDIForRepositoryClasses(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
        }
    }
}