using Nefe.Domain;
using System.Data.Entity;

namespace Nefe.Service
{
    public class NefeDataContext : DbContext
    {
        public NefeDataContext()
            : base("DefaultConnection")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(m => 
                {
                    m.ToTable("UserRoles");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId"); 
                });
        }
    }
}
