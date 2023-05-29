using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Repository.DataBase
{
    public class ExamStudentConfiguration : IEntityTypeConfiguration<ExamStudent>
    {
        public void Configure(EntityTypeBuilder<ExamStudent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();
            builder.Property(x => x.ExamId).IsRequired();
            builder.Property(x => x.StudentId).IsRequired();
        }
    }
}
