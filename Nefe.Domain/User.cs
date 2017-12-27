using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nefe.Domain
{
    public class User : Entity
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public string FullName { get { return string.Format("{0} {1}", Name, LastName); } }
        [StringLength(11)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public bool Gender { get; set; }
        public DateTime? BirthDate { get; set; }
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
