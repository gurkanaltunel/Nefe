using Nefe.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nefe.Service.Interfaces
{
    public interface IAccountService
    {
        UserDto Login(string email, string password);

        bool Register(UserDto user);
    }
}
