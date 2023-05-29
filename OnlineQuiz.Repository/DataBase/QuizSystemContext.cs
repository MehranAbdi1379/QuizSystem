using Framework.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Value_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Repository.DataBase
{
    public class QuizSystemContext : DataBaseContext<ApiUser>
    {
        public QuizSystemContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new ProfessorConfiguration());
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new CourseStudentConfiguration());
            builder.ApplyConfiguration(new ExamConfiguration());
            builder.ApplyConfiguration(new DescriptiveQuestionConfiguration());
            builder.ApplyConfiguration(new MultipleChoiceAnswerConfiguration());
            builder.ApplyConfiguration(new MultipleChoiceQuestionConfiguration());
            builder.ApplyConfiguration(new GradedQuestionConfiguration());
            builder.ApplyConfiguration(new ExamStudentConfiguration());
            builder.ApplyConfiguration(new ExamStudentQuestionConfiguration());

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Course> Courses{ get; set; }
        public DbSet<CourseStudent> CourseStudent { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<DescriptiveQuestion> DescriptiveQuestions { get; set; }
        public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
        public DbSet<MultipleChoiceAnswer> MultipleChoiceAnswers { get; set; }
        public DbSet<GradedQuestion> GradedQuestions { get; set; }
        public DbSet<ExamStudent> ExamStudent { get; set; }
        public DbSet<ExamStudentQuestion> ExamStudentQuestion { get; set; }
    }
}