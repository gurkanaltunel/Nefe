using Nefe.Domain;
using System.Data.Entity;

namespace Nefe.Service
{
    public class NefeDataContext : DbContext
    {
        public NefeDataContext()
            : base("DefaultConnection")
        { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPackage> ProductPackages { get; set; }
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

            modelBuilder.Entity<Product>().Property(x => x.UnitPrice).HasPrecision(5, 2);
            modelBuilder.Entity<Product>().Property(x => x.Quantity).HasPrecision(4, 2);
            modelBuilder.Entity<Product>().Property(x => x.TotalStockAmount).HasPrecision(7, 2);
        }
    }
}
