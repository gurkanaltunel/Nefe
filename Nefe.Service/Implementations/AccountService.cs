using Nefe.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nefe.Service.Repository.Interface;
using Nefe.Service.UnitOfWorks;
using Nefe.Service.Dto;

namespace Nefe.Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UnitOfWork _unitOfWork;

        public AccountService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public UserDto Login(string email, string password)
        {
            return _unitOfWork.UserRepository.Select(x => x.Email == email && x.Password == password).Select(x => new UserDto
                {
                    Id = x.Id,
                    Email = x.Email,
                    Name = x.Name,
                    LastName = x.LastName,
                    Roles = x.Roles.Select(t => new RoleDto { RoleName = t.RoleName }).ToList()
                }).FirstOrDefault();
        }

        public bool Register(UserDto user)
        {
            var newUser = _unitOfWork.UserRepository.Insert(new Domain.User
               {
                   Name = user.Name,
                   LastName = user.LastName,
                   Email = user.Email,
                   Password = user.Password,
                   Roles = user.Roles.Select(t => new Domain.Role { RoleName = t.RoleName }).ToList()
               });
            _unitOfWork.Save();
            if (newUser != null)
            {
                return true;
            }
            return false;
        }
    }
}
