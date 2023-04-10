using Framework.Repository;
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
    public class StudentRepository: BaseRepository<Student , ApiUser> , IStudentRepository
    {
        public StudentRepository(QuizSystemContext context) : base(context)
        {

        }
    }
}
