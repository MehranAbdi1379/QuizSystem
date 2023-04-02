using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Models
{
    public class CourseStudent
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
    }
}