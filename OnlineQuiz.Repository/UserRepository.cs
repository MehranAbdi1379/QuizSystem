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
using System.Runtime.InteropServices;
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

        public async Task<List<ApiUser>> Filter(string firstName, string lastName, string role="")
        {
            var result= new List<ApiUser>();
            var users = userManager.Users.Where(s => s.FirstName.ToLower().Contains(firstName.ToLower()) &&
            s.LastName.ToLower().Contains(lastName.ToLower())).ToList();
            if (role.IsNullOrEmpty())
            {
                return users;
            }

            foreach (var item in users)
            {
                bool isInRole = await userManager.IsInRoleAsync(item, role);
                if (isInRole)
                {
                    result.Add(item);
                }
            }
            

            return result;
        }

        public string GetUserRole(string userName)
        {
            return userManager.GetRolesAsync(userManager.FindByNameAsync(userName).Result).Result.ToList().First();
        }
    }
}