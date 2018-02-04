﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nefe.Service.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<RoleDto> Roles{ get; set; }
    }
}
