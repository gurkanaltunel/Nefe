using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nefe.Service.Interfaces;
using Nefe.Service.IoC;
using Nefe.Service.Dto;

namespace Nefe.Api.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
       
        public UserDto Login(string email,string password)
        {
            var user = _accountService.Login(email, password);
            return user;
        }

        public bool Register(UserDto user)
        {
            return _accountService.Register(user);
        }
    }
}