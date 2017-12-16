using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nefe.Domain
{
    public class User : Entity
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Format("{0} {1}", Name, LastName); } }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PostalAddress { get; set; }
        public DateTime BirthDate { get; set; }
        public bool MemberOfBulletin { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
