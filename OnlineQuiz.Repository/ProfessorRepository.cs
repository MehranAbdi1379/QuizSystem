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
    public class ProfessorRepository : UserRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(QuizSystemContext context) : base(context)
        {
        }

        public List<Professor> Filter(string firstName, string lastName, string nationalCode)
        {
            return context.Set<Professor>().Where(s => s.FirstName.ToLower().Contains(firstName.ToLower()) &&
            s.LastName.ToLower().Contains(lastName.ToLower()) && s.NationalCode.Contains(nationalCode)).ToList();
        }
    }
}