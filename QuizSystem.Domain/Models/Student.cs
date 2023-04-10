using Framework.Core.Domain;
using Framework.Domain;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Models
{
    public class Student : BaseEntity
    {
        public Student()
        {

        }

        public Student(Guid id,
            bool accepted = false) : base(id)
         {
            SetAccepted(accepted);
        }

        public bool Accepted { get; private set; } = false;
        

        public void SetAccepted(bool accepted)
        {
            Accepted = accepted;
        }
    }
}
