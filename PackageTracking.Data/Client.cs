using PackageTracking.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackageTracking.Data
{
    public partial class Client : IAuditable
    {
        public Client()
        {
            Warehouse = new HashSet<Warehouse>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public virtual ICollection<Warehouse> Warehouse { get; set; }

        public bool Enabled { get; set; }

        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }

    }
}
