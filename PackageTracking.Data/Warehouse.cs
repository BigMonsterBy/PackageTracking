using PackageTracking.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackageTracking.Data
{
    public partial class Warehouse : IAuditable
    {
        public Warehouse()
        {
            UserRole = new HashSet<UserRole>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseId { get; set; }

        public int? ClientId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }

        public bool Enabled { get; set; }

        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
    }
}
