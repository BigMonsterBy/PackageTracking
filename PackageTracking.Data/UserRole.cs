using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PackageTracking.Data
{
    [Table("UserRole")]
    public partial class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int UserRoleId { get; set; }

        public int UserId { get; set; }

        public int WarehouseId { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
