using QuizSystem.Repository;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Service;
using QuizSystem.Service.Contracts;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using QuizSystem.Repository.DataBase;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.IdentityModel.Logging;
using Serilog;
using System.Runtime.CompilerServices;
using Microsoft.OpenApi.Models;

namespace QuizSystem.API.Extensions
{
    public static class AddServices
    {
        public static void AddDIForServiceClasses(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IProfessorService, ProfessorService>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddScoped<IExamService, ExamService>();
            builder.Services.AddScoped<IMultipleChoiceQuestionService , MultipleChoiceQuestionService>();
            builder.Services.AddScoped<IDescriptiveQuestionService, DescriptiveQuestionService>();
            builder.Services.AddScoped<IGradedQuestionService, GradedQuestionService>();
            builder.Services.AddScoped<IExamStudentService, ExamStudentService>();
        }

        public static void AddDIForRepositoryClasses(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IProfessorRepository , ProfessorRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICourseStudentRepository, CourseStudentRepository>();
            builder.Services.AddScoped<IExamRepository, ExamRepository>();
            builder.Services.AddScoped<IDescriptiveQuestionRepository, DescriptiveQuestionRepository>();
            builder.Services.AddScoped<IMultipleChoiceAnswerRepository, MultipleChoiceAnswerRepository>();
            builder.Services.AddScoped<IMultipleChoiceQuestionRepository, MultipleChoiceQuestionRepository>();
            builder.Services.AddScoped<IGradedQuestionRepository, GradedQuestionRepository>();
            builder.Services.AddScoped<IExamStudentRepository, ExamStudentRepository>();
            builder.Services.AddScoped<IExamStudentQuestionRepository, ExamStudentQuestionRepository>();
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<ApiUser, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
                o.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<QuizSystemContext>()
            .AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection service, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");
            var secretKey = Environment.GetEnvironmentVariable("KEY");
            service.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new
    SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

        }

        public static void AddSwagger(this IServiceCollection service)
        {
            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "jwtToken_Auth_API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Here Enter JWT Token with bearer format like bearer[space] token"
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
            new string[]{}
        }
    });
            });
        }
    }
}
