namespace PackageTracking.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class PackageTrackingContext : DbContext
    {
        public PackageTrackingContext()
            : base("name=PackageTrackingContext")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .ToTable("Client");

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRole)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .ToTable("User")
                .HasMany(e => e.UserRole)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.UserRole)
                .WithRequired(e => e.Warehouse)
                .WillCascadeOnDelete(false);
        }
    }
}
