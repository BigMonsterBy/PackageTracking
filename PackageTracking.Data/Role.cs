namespace PackageTracking.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Role")]
    public class Role
    {
        public Role()
        {
            UserRole = new HashSet<UserRole>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public int Access { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
