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
    public static class DescriptiveQuestionSeedData
    {
        public async static Task SeedData(QuizSystemContext context)
        {
            var courses = context.Set<Course>().ToList().Select(x => new { x.ProfessorId, x.Id});

            var facker = new Faker<DescriptiveQuestion>()
                .RuleFor(e => e.Description, f => f.Lorem.Sentence())
                .RuleFor(e => e.Title, f => { var randomWord = f.Random.Word(); return randomWord.Length < 20 ? randomWord : randomWord.Substring(0, 18);})
                .RuleFor(e => e.ProfessorId, f => f.PickRandom(courses.Select(c => c.ProfessorId)))
                .RuleFor(e => e.CourseId , f => f.PickRandom(courses.Select(c => c.Id)));

            var dummyDescriptiveQuestions = facker.Generate(200);

            foreach (var descriptiveQuestion in dummyDescriptiveQuestions)
            {
                context.Set<DescriptiveQuestion>().Add(descriptiveQuestion);
            }
            context.SaveChanges();
        }
    }
}
