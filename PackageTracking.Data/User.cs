using PackageTracking.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PackageTracking.Data
{
    public class User : IAuditable
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
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public bool IsGlobalAdmin { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }

        [Display(Name = "Статус")]
        public bool Enabled { get; set; }

        [Required]
        public DateTime LastLogOn { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(20)]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Добавлен")]
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }

        [Display(Name = "Изменен")]
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }

        [Display(Name = "Добавил")]
        public virtual User Creator { get; set; }

        [Display(Name = "Изменил")]
        public virtual User Modifier { get; set; }
    }
}
