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
    public class AdminService
    {
        protected readonly IUserRepository<Admin> repository;

        public AdminService(IUserRepository<Admin> repository)
        {
            this.repository = repository;
        }

        public Admin CreateAdmin(StudentAndProfessorCreateDTO dto)
        {
            var admin = new Admin(dto.FirstName,
                dto.LastName,
                dto.NationalCode,
                dto.Password,
                dto.BirthDate,
                repository);

            repository.Create(admin);
            repository.Save();

            return admin;
        }



        public Admin RemoveAdmin(StudentAndProfessorIdDTO dto)
        {
            Admin student = repository.GetWithId(dto.Id);

            repository.Delete(student);
            repository.Save();

            return student;
        }

        public Admin UpdateAdmin(StudentAndProfessorUpdateDTO dto)
        {
            Admin student = repository.GetWithId(dto.Id);

            student.SetFirstName(dto.FirstName);
            student.SetLastName(dto.LastName);
            student.SetNationalCode(dto.NationalCode, repository);
            student.SetBirthDate(dto.BirthDate);

            repository.Update(student);
            repository.Save();

            return student;
        }
    }
}
