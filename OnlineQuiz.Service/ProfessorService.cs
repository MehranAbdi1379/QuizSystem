using OnlineQuiz.Service.Contracts.DTO;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.Service
{
    public class ProfessorService
    {
        protected readonly IProfessorRepository repository;

        public ProfessorService(IProfessorRepository repository)
        {
            this.repository = repository;
        }

        public Professor CreateStudent(CreateProfessorDTO dto)
        {
            var professor = new Professor(dto.FirstName,
                dto.LastName,
                dto.NationalCode,
                dto.Password,
                dto.BirthDate,
                repository);

            repository.Create(professor);
            repository.Save();

            return professor;
        }

        public void RemoveStudent(RemoveProfessorDTO dto)
        {
            Professor professor = repository.GetUserFromNationalCodeAndPassword(dto.NationalCode, dto.Password);

            repository.Delete(professor);
        }

        public Professor AcceptStudent(AcceptProfessorDTO dto)
        {
            Professor professor = repository.GetUserFromNationalCodeAndPassword(dto.NationalCode, dto.Password);

            professor.Accepted = true;

            repository.Update(professor);

            return professor;
        }
    }
}