using Framework.Core.Domain;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Repository;
using QuizSystem.Domain.Value_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Models
{
    public class Course : BaseEntity
    {
        public Course()
        {

        }

        public Course(string title, 
            DateTime startTime,
            DateTime endTime ,
            ICourseRepository repository ,
            List<Guid> studentIds ,
            Guid professorId ,
            IUserRepository<Professor> professorRepository,
            IUserRepository<Student> studentRepository)
        {
            SetTitle(title, repository);
            SetTime(startTime, endTime);
            SetProfessor(professorId,professorRepository);
        }

        public string Title { get; private set; }
        public TimePeriod TimePeriod { get; private set; }
        public Professor Professor { get; private set; }

        public void SetTitle(string title , ICourseRepository repository)
        {
            if (repository.CourseTitleExists(title))
                throw new CourseTitleExistsException();
            Title = title;
        }

        public void SetTime(DateTime startTime , DateTime endTime)
        {
            TimePeriod = new TimePeriod(startTime, endTime);
        }

        public void SetProfessor(Guid professorId , IUserRepository<Professor> professorRepository)
        {
            if (professorRepository.IsExist(professorId) == false)
                throw new CourseProfessorNotExistException();
            Professor = professorRepository.GetWithId(professorId);
        }
    }
}