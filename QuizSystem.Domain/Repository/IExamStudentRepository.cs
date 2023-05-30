using Framework.Repository;
using QuizSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Repository
{
    public interface IExamStudentRepository: IBaseRepository<ExamStudent>
    {
        public bool ExamStudentAlreadyExist(Guid examId, Guid studentId);
        public ExamStudent GetByExamAndStudentId(Guid examId, Guid studentId);
        List<ExamStudent> GetAllByExamId(Guid examId);

    }
}
