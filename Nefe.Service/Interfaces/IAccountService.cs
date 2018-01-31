using Nefe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nefe.Service.Interfaces
{
    public interface IAccountService
    {
        string Login(string email, string password);
    }
}
