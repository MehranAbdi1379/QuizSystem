using Bogus;
using Microsoft.AspNetCore.Identity;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Value_Object;
using QuizSystem.Repository.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Repository.SeedData
{
    public static class CourseSeedData
    {
        public async static Task SeedData(QuizSystemContext context , UserManager<ApiUser> userManager)
        {
            var professorIds = userManager.GetUsersInRoleAsync("professor").Result.Select(u => Guid.Parse(u.Id)).ToList();

            var courseFaker = new Faker<Course>()
                .RuleFor(c => c.Title, f => f.Random.Words(2))
                .RuleFor(c => c.TimePeriod, f => new TimePeriod(DateTime.Now.AddDays(f.Random.Number(1,60)), f.Date.Future(2,DateTime.Now)))
                .RuleFor(c => c.ProfessorId, f => f.PickRandom(professorIds));

            List<Course> dummyCourses = courseFaker.Generate(20);

            foreach (var course in dummyCourses)
            {
                context.Set<Course>().Add(course);
            }
            context.SaveChanges();
        }
    }
}
