using Bogus;
using QuizSystem.Domain.Models;
using QuizSystem.Repository.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Repository.SeedData
{
    public static class ExamSeedData
    {
        public async static Task SeedData(QuizSystemContext context)
        {
            var courseIds = context.Set<Course>().Select(c => c.Id).ToList();

            var examFaker = new Faker<Exam>()
                .RuleFor(e => e.Title, f => f.Random.Words(2))
                .RuleFor(e => e.Description, f => f.Lorem.Sentence())
                .RuleFor(e => e.Time, f => f.Random.Int(15, 180))
                .RuleFor(e => e.CourseId, f => f.PickRandom(courseIds));

            List<Exam> dummyExams = examFaker.Generate(40);

            foreach (var exam in dummyExams)
            {
                context.Set<Exam>().Add(exam);
            }
            context.SaveChanges();
        }
    }
}
