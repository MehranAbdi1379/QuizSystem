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
    public class AdminService : IAdminService
    {
        protected readonly IUserRepository<Admin> repository;

        public AdminService(IUserRepository<Admin> repository)
        {
            this.repository = repository;
        }

        public Admin CreateAdmin(UserCreateDTO dto)
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



        public Admin RemoveAdmin(UserIdDTO dto)
        {
            Admin admin = repository.GetWithId(dto.Id);

            repository.Delete(admin);
            repository.Save();

            return admin;
        }

        public Admin UpdateAdmin(UserUpdateDTO dto)
        {
            Admin admin = repository.GetWithId(dto.Id);

            admin.SetFirstName(dto.FirstName);
            admin.SetLastName(dto.LastName);
            admin.SetNationalCode(dto.NationalCode, repository);
            admin.SetBirthDate(dto.BirthDate);

            repository.Update(admin);
            repository.Save();

            return admin;
        }
    }
}
