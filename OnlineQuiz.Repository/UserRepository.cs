using Framework.Core.Domain;
using Framework.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Repository.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Repository
{
    public class UserRepository 
    {

        private readonly UserManager<ApiUser> userManager;
        public UserRepository(UserManager<ApiUser> userManager)
        {
            this.userManager = userManager;
        }

        public List<ApiUser> Filter(string firstName, string lastName, string nationalCode , string role)
        {
            var result= new List<ApiUser>();
            var users = userManager.Users.Where(s => s.FirstName.ToLower().Contains(firstName.ToLower()) &&
            s.LastName.ToLower().Contains(lastName.ToLower()) && s.NationalCode.Contains(nationalCode)).ToList();
            foreach (var item in users)
            {
                if (userManager.IsInRoleAsync(item,role).Result)
                {
                    result.Add(item);
                }
            }
            if (role.IsNullOrEmpty())
            {
                return users;
            }

            return result;
        }

        public List<string> GetUserRoles(string userName)
        {
            return userManager.GetRolesAsync(userManager.FindByNameAsync(userName).Result).Result.ToList();
        }
    }
}