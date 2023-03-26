using Framework.Repository;
using OnlineQuiz.Repository.Exceptions;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.Repository
{
    public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(DataBaseContext context) : base(context)
        {
        }

        public bool NationalCodeExists(string nationalCode)
        {
            return context.Set<Professor>().Any(s => s.NationalCode == nationalCode);
        }

        public Professor GetUserFromNationalCodeAndPassword(string nationalCode, string password)
        {
            try
            {
                return context.Set<Professor>().Where(s => s.Password == password && s.NationalCode == nationalCode).First();
            }
            catch (ProfessorNoMatchForNationalCodeAndPasswordException ex)
            {
                throw ex;
            }

        }
    }
}
