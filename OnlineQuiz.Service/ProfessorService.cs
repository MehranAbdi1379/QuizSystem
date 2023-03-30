using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service
{
    //public class ProfessorService : IProfessorService
    //{
    //    protected readonly IProfessorRepository repository;

    //    public ProfessorService(IProfessorRepository repository)
    //    {
    //        this.repository = repository;
    //    }

    //    public Professor CreateProfessor(ProfessorDTO dto)
    //    {
    //        var professor = new Professor(dto.FirstName,
    //            dto.LastName,
    //            dto.NationalCode,
    //            dto.Password,
    //            dto.BirthDate,
    //            repository);

    //        repository.Create(professor);
    //        repository.Save();

    //        return professor;
    //    }

    //    public void RemoveProfessor(ProfessorDTO dto)
    //    {
    //        Professor professor = repository.GetProfessorFromNationalCodeAndPassword(dto.NationalCode, dto.Password);

    //        repository.Delete(professor);
    //    }

    //    public Professor AcceptProfessor(ProfessorDTO dto)
    //    {
    //        Professor professor = repository.GetProfessorFromNationalCodeAndPassword(dto.NationalCode, dto.Password);

    //        professor.Accepted = true;

    //        repository.Update(professor);

    //        return professor;
    //    }
    //}
}