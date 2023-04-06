using QuizSystem.API.Extensions;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Service.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service
{
    public class UserSearchService : IUserSearchService
    {
        private readonly IUserRepository<Student> studentRepository;
        private readonly IUserRepository<Professor> professorRepository;
        public UserSearchService(IUserRepository<Student> studentRepository, IUserRepository<Professor> professorRepository)
        {
            this.studentRepository = studentRepository;
            this.professorRepository = professorRepository;
        }

        public StudentAndProfessorSearchResultDTO SearchForUser(StudentProfessorSearchDTO dto)
        {
            StudentAndProfessorSearchResultDTO result = new StudentAndProfessorSearchResultDTO();
            result.Students = studentRepository.Filter(dto.FirstName, dto.LastName, dto.NationalCode);
            result.Professors = professorRepository.Filter(dto.FirstName, dto.LastName, dto.NationalCode);
            return result;
        }
    }
}
