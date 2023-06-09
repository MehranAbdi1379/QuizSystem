﻿using Framework.Repository;
using QuizSystem.Domain.Models;

namespace QuizSystem.Domain.Repository
{
    public interface IExamRepository : IBaseRepository<Exam>
    {
        bool IsExamTitleExist(string title, Guid courseId);
        List<Exam> GetAllExams(Guid courseId);
    }
}