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
            IProfessorRepository professorRepository,
            IStudentRepository studentRepository)
        {
            SetTitle(title, repository);
            SetTime(startTime, endTime);
            SetProfessor(professorId,professorRepository);
            SetStudents(studentIds , studentRepository);
        }

        public string Title { get; private set; }
        public TimePeriod TimePeriod { get; private set; }
        public List<Guid> StudentIds { get; private set; }
        public Guid ProfessorId { get; private set; }

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

        public void SetProfessor(Guid professorId , IProfessorRepository professorRepository)
        {
            if (professorRepository.IsExist(professorId) == true)
                throw new CourseProfessorNotExistException();
            ProfessorId = professorId;
        }

        public void SetStudents(List<Guid> studentIds , IStudentRepository studentRepository)
        {
            foreach (var item in studentIds)
            {
                if(studentRepository.IsExist(item))
                    throw new CourseStudentAddNotExistException();
            }
            StudentIds = studentIds;
        }

        public void AddStudent(Guid studentId, IStudentRepository studentRepository)
        {
            if (studentRepository.IsExist(studentId) == false)
                throw new CourseStudentAddNotExistException();
            if (StudentIds.Any(x => x == studentId))
                throw new CourseAddStudentAlreadyExistsException();
            StudentIds.Add(studentId);
        }
    }
}