﻿using Framework.Repository;
using Microsoft.EntityFrameworkCore;
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
    public class CourseRepository : BaseRepository<Course,ApiUser> , ICourseRepository
    {
        public CourseRepository(QuizSystemContext context) : base(context)
        {

        }

        public bool IsCourseTitleExist(string title)
        {
            return context.Set<Course>().Any(s => s.Title == title);
        }
        public List<Course> GetByProfessorId(Guid professorID)
        {
            return context.Set<Course>().Where(p => p.ProfessorId == professorID).ToList();
        }
        public List<Course> GetAllCourses()
        {
            return context.Set<Course>().ToList();
        }
    }
}