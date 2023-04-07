using QuizSystem.Repository;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Service;
using QuizSystem.Service.Contracts;

namespace QuizSystem.API.Extensions
{
    public static class AddServices
    {
        public static void AddDIForServiceClasses(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IProfessorService, ProfessorService>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IUserSearchService,UserSearchService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
        }

        public static void AddDIForRepositoryClasses(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserRepository<Student>, UserRepository<Student>>();
            builder.Services.AddScoped<IUserRepository<Professor> , UserRepository<Professor>>();
            builder.Services.AddScoped<IUserRepository<Admin>, UserRepository<Admin>>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICourseStudentRepository, CourseStudentRepository>();
        }
    }
}
