namespace PackageTracking.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using PackageTracking.Data.Interfaces;
    using System.Threading;
    using PackageTracking.Core.Interfaces;
    using PackageTracking.Core;

    public class PackageTrackingContext : DbContext
    {
        private readonly IUserContextProvider _userContextProvider;

        public PackageTrackingContext(IUserContextProvider userContextProvider)
            : base("name=PackageTrackingContext")
        {
            _userContextProvider = userContextProvider;
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
                .ToTable("Role")
                .HasMany(e => e.UserRole)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .ToTable("User")
                .HasMany(e => e.UserRole)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Warehouse>()
                .ToTable("Warehouse")
                .HasMany(e => e.UserRole)
                .WithRequired(e => e.Warehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ship>()
                .ToTable("Ship")
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Ship);

            modelBuilder.Entity<Order>()
                .ToTable("Order")
                .HasMany(e => e.Packs)
                .WithRequired(e => e.Order);

            modelBuilder.Entity<Pack>()
                .ToTable("Pack")
                .HasMany(e => e.Details)
                .WithOptional(e => e.Pack);
        }

        public override int SaveChanges()
        {
            var auditDate = DateTime.UtcNow;
            var userContext = _userContextProvider.GetUserContext();
            foreach (var entry in ChangeTracker.Entries<IAuditable>().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = auditDate;
                        entry.Entity.ModifiedOn = auditDate;
                        entry.Entity.CreatedBy = userContext.UserId;
                        entry.Entity.ModifiedBy = userContext.UserId;
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Property(w => w.CreatedOn).IsModified = false;
                        entry.Property(w => w.CreatedBy).IsModified = false;
                        entry.Entity.ModifiedOn = auditDate;
                        entry.Entity.ModifiedBy = userContext.UserId;
                        break;
                }
            }
            try
            {
                return base.SaveChanges();
            }
            catch (Exception e) {
               var c= e.InnerException;
                return 0;
            }
        }
    }
}
