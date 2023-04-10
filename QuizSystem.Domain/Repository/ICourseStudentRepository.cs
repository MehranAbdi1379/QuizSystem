﻿using Framework.Repository;
using QuizSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Repository
{
    public interface ICourseStudentRepository : IBaseRepository<CourseStudent> 
    {
        List<CourseStudent> GetWithCourseId(Guid courseId);
        List<CourseStudent> GetWithStudentId(Guid studentId);
    }
}
