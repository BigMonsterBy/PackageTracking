namespace PackageTracking.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class User
    {
        public User()
        {
            UserRole = new HashSet<UserRole>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public bool IsGlobalAdmin { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
