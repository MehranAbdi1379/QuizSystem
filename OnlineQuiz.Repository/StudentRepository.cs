using Framework.Repository;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizSystem.Repository.DataBase;
using System.Text.RegularExpressions;
using QuizSystem.Repository;

namespace OnlineQuiz.Repository
{


    public class StudentRepository : UserRepository<Student>, IUserRepository<Student>
    {
        public StudentRepository(QuizSystemContext context) : base(context)
        {
        }

        public List<Student> Filter(string firstName , string lastName , string nationalCode)
        {
            return context.Set<Student>().Where(s => s.FirstName.ToLower().Contains(firstName.ToLower()) &&
            s.LastName.ToLower().Contains(lastName.ToLower()) && s.NationalCode.Contains(nationalCode)).ToList();
        }
    }
}