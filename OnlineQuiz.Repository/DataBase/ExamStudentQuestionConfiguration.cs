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
    public class ExamStudentQuestionConfiguration : IEntityTypeConfiguration<ExamStudentQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamStudentQuestion> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Answer).IsRequired();
            builder.Property(x => x.GradedQuestionId).IsRequired();
            builder.Property(x => x.ExamStudentId).IsRequired();
        }
    }
}
