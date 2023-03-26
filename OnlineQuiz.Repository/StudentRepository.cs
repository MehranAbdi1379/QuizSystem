using Framework.Repository;
using OnlineQuiz.Repository.Exceptions;
using QuizSystem.Domain;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.Repository
{
    

    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(DataBaseContext context) : base(context)
        {
        }

        public bool NationalCodeExists(string nationalCode)
        {
            return context.Set<Student>().Any(s => s.NationalCode == nationalCode);
        }

        public Student GetUserFromNationalCodeAndPassword(string nationalCode , string password)
        {
            try
            {
                return context.Set<Student>().Where(s => s.Password == password && s.NationalCode == nationalCode).First();
            }
            catch (StudentNoMatchForNationalCodeAndPasswordException ex)
            {
                throw ex;
            }
            
        }
    }
}
