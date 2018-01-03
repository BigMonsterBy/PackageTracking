namespace PackageTracking.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Client
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
    }
}
