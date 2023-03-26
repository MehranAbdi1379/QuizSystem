using Framework.Repository;
using Microsoft.EntityFrameworkCore;
using QuizSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.Repository.DataBase
{
    public class OnlineQuizContext : DataBaseContext
    {
        public OnlineQuizContext(DbContextOptions<OnlineQuizContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Student>().HasKey(s => s.Id);
            model.Entity<Student>().Property(s => s.Id).IsRequired();
            model.Entity<Student>().Property(s => s.Password).IsRequired().HasMaxLength(50);
            model.Entity<Student>().Property(s => s.FirstName).IsRequired().HasMaxLength(50);
            model.Entity<Student>().Property(s => s.LastName).IsRequired().HasMaxLength(50);
            model.Entity<Student>().Property(s => s.NationalCode).IsRequired().HasMaxLength(10);
            model.Entity<Student>().Property(s => s.BirthDate).IsRequired();

            model.Entity<Professor>().HasKey(p => p.Id);
            model.Entity<Professor>().Property(p => p.Id).IsRequired();
            model.Entity<Professor>().Property(p => p.Password).IsRequired().HasMaxLength(50);
            model.Entity<Professor>().Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            model.Entity<Professor>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
            model.Entity<Professor>().Property(p => p.NationalCode).IsRequired().HasMaxLength(10);
            model.Entity<Professor>().Property(p => p.BirthDate).IsRequired();

            model.Entity<Course>().HasKey(c => c.Id);
            model.Entity<Course>().Property(c => c.Id).IsRequired();
            model.Entity<Course>().Property(c => c.Title).IsRequired().HasMaxLength(150);
            model.Entity<Course>().Property(c => c.StartTime).IsRequired();
            model.Entity<Course>().Property(c => c.EndTime).IsRequired();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Course> Courses{ get; set; }
    }
}