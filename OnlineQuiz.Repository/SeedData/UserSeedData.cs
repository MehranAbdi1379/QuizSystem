using Bogus;
using Microsoft.AspNetCore.Identity;
using QuizSystem.Domain.Models;
using QuizSystem.Repository.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Repository.SeedData
{
    public static class UserSeedData
    {
        public static async Task SeedData(UserManager<ApiUser> userManager)
        {
            var faker = new Faker<ApiUser>()
            .RuleFor(u => u.FirstName, f => f.Person.FirstName)
            .RuleFor(u => u.LastName, f => f.Person.LastName)
            .RuleFor(u => u.BirthDate, f => f.Date.Between(new DateTime(1970, 1, 1), new DateTime(1999, 12, 31)))
            .RuleFor(u => u.NationalCode, f => f.Random.Replace("##########"));

            List<ApiUser> dummyUsers = faker.Generate(20);

            foreach (var user in dummyUsers)
            {
                user.UserName = user.NationalCode;
                await userManager.CreateAsync(user, "123456");
                await userManager.AddToRoleAsync(user, "student");
            }

            dummyUsers = faker.Generate(20);

            foreach (var user in dummyUsers)
            {
                user.UserName = user.NationalCode;
                await userManager.CreateAsync(user, "123456");
                await userManager.AddToRoleAsync(user, "professor");
            }

            var admin = new ApiUser() { FirstName = "Mehran", LastName = "Abdi"
                , BirthDate = new DateTime(2000, 10, 28) , NationalCode = "2741723486"};
            admin.UserName = admin.NationalCode;
            await userManager.CreateAsync(admin, "mehran123456");
        }
    }
}
