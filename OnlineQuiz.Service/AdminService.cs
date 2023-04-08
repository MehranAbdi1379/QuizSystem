using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Service.Exceptions;
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

        public AdminSignedInDTO AdminSignIn(UserSignInDTO dto)
        {
            try
            {
                var admin = repository.GetWithNationalCodeAndPassword(dto.NationalCode, dto.Password);
                return new AdminSignedInDTO() { 
                    Id = admin.Id,
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    NationalCode = admin.NationalCode,
                    Password = admin.Password,
                    BirthDate = admin.BirthDate,
                };
            }
            catch (Exception ex)
            {
                throw new AdminSignInWrongNationalCodeOrPasswordException();
            }
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
