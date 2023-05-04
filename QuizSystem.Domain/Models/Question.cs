using Framework.Core.Domain;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Repository;
using QuizSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Models
{
    public class Question : BaseEntity
    {
        public Question()
        {

        }

        public Question( string description, Guid professorId, Guid courseId, IProfessorRepository professorRepository, ICourseRepository courseRepository) 
        {
            SetProfessorId(professorId, professorRepository);
            SetCourseId(courseId, courseRepository);
            Description = description;
        }

        public string Description { get;  set; }
        public Guid ProfessorId { get; private set; }
        public Guid CourseId { get; private set; }

        public void SetProfessorId(Guid professorId , IProfessorRepository professorRepository)
        {
            if (!professorRepository.IsExist(professorId))
                throw new ProfessorIdNotExistException();
            ProfessorId = professorId;
        }

        public void SetCourseId(Guid courseId, ICourseRepository courseRepository)
        {
            if (!courseRepository.IsExist(courseId))
                throw new CourseNotExistException();
            CourseId = courseId;
        }
    }
}
