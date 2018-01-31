using Nefe.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nefe.Domain;
using Nefe.Service.Repository.Interface;
using Nefe.Service.UnitOfWorks;

namespace Nefe.Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UnitOfWork _unitOfWork;

        public AccountService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public string Login(string email, string password)
        {
            return "asd";
            //return _unitOfWork.UserRepository.Select(x => x.Email == email && x.Password == password).FirstOrDefault();
        }
    }
}
