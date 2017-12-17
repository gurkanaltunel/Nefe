using System;
using System.Collections.Generic;

namespace Nefe.Domain
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Format("{0} {1}", Name, LastName); } }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool MemberOfBulletin { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Address> Addresses { get; set; }

        public User()
        {
            Roles = new List<Role>();
            Addresses = new List<Address>();
        }
    }
}
