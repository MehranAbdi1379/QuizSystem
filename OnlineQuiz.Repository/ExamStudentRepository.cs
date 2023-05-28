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
    public class ExamStudentRepository : BaseRepository<ExamStudent, ApiUser> , IExamStudentRepository
    {
        public ExamStudentRepository(QuizSystemContext context) : base(context)
        {
        }

        public bool ExamStudentAlreadyExist(Guid examId , Guid studentId)
        {
            return context.Set<ExamStudent>().Any(x => x.ExamId == examId && x.StudentId == studentId);
        }

        public ExamStudent GetByExamAndStudentId(Guid examId , Guid studentId)
        {
            return context.Set<ExamStudent>().Where(x => x.StudentId == studentId && x.ExamId == examId).First();
        }
    }
}
