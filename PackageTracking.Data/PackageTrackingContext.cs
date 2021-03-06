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
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Ship> Ship { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .ToTable("Client")
                .HasRequired(e => e.Creator)
                .WithMany()
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Client>()
                .HasRequired(e => e.Modifier)
                .WithMany()
                .HasForeignKey(e => e.ModifiedBy);

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

            modelBuilder.Entity<User>()
                .HasRequired(e => e.Creator)
                .WithMany()
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<User>()
                .HasRequired(e => e.Modifier)
                .WithMany()
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Warehouse>()
                .ToTable("Warehouse")
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.Warehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Warehouse>()
                .HasRequired(e => e.Creator)
                .WithMany()
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Warehouse>()
                .HasRequired(e => e.Modifier)
                .WithMany()
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Warehouse>()
                .HasRequired(e => e.Client);

            modelBuilder.Entity<Ship>()
                .ToTable("Ship")
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Ship);

            modelBuilder.Entity<Ship>()
                .Property(e => e.ShipID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

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
            return base.SaveChanges();
        }
    }
}
