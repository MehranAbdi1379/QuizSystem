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
            List<Student> students ,
            Guid professorId ,
            IProfessorRepository professorRepository)
        {
            SetTitle(title, repository);
            SetTime(startTime, endTime);
            SetProfessor(professorId,professorRepository);
            SetStudents(students);
        }

        public string Title { get; private set; }
        public TimePeriod TimePeriod { get; private set; }
        public List<Student> Students { get; private set; }
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
            if (professorRepository.GetWithId(professorId) == null)
                throw new CourseProfessorNullException();
            ProfessorId = professorId;
        }

        public void SetStudents(List<Student> students)
        {
            Students = students;
        }

        public void AddStudent(Student student, IStudentRepository studentRepository)
        {
            if (studentRepository.GetWithId(student.Id) == null)
                throw new CourseStudentAddNotExistException();
            if (Students.Any(x => x.Id ==student.Id))
                throw new CourseAddStudentAlreadyExistsException();
            Students.Add(student);
        }
    }
}