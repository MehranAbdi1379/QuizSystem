using Framework.Repository;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizSystem.Repository.DataBase;

namespace OnlineQuiz.Repository
{


    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(QuizSystemContext context) : base(context)
        {
        }

        public bool NationalCodeExists(string nationalCode)
        {
            return context.Set<Student>().Any(s => s.NationalCode == nationalCode);
        }
    }
}
