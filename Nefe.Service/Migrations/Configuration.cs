using System.Collections.Generic;
using Nefe.Domain;

namespace Nefe.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<NefeDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NefeDataContext context)
        {
            var role1 = new Role { RoleName = "Admin" };
            var role2 = new Role { RoleName = "User" };

            var user1 = new User { Email = "admin1@ymail.com", Name = "Admin1", Password = "123456", IsActive = true, CreateDate = DateTime.UtcNow, Roles = new List<Role>(), BirthDate = new DateTime(1986, 1, 1), MemberOfBulletin = false };
            var user2 = new User { Email = "user1@ymail.com", Name = "User1", Password = "123456", IsActive = true, CreateDate = DateTime.UtcNow, Roles = new List<Role>(), BirthDate = new DateTime(1986, 10, 10), MemberOfBulletin = true };
            user1.Roles.Add(role1);
            user2.Roles.Add(role2);
            context.Users.Add(user1);
            context.Users.Add(user2);
        }
    }
}
