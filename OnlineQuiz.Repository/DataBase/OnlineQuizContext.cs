using Framework.Repository;
using Microsoft.EntityFrameworkCore;
using QuizSystem.Domain;
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
            model.Entity<Student>().Property(s => s.Password).IsRequired();
            model.Entity<Student>().Property(s => s.FirstName).IsRequired();
            model.Entity<Student>().Property(s => s.LastName).IsRequired();
            model.Entity<Student>().Property(s => s.NationalCode).IsRequired();
            model.Entity<Student>().Property(s => s.BirthDate).IsRequired();
        }

        public DbSet<Student> Students { get; set; }
    }
}