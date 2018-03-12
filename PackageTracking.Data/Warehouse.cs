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
            UserRoles = new HashSet<UserRole>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseId { get; set; }

        public int? ClientId { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name="��������")]
        public string Name { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        [Display(Name = "������")]
        public bool Enabled { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name="Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name="����������� �����")]
        public string Address { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name="������������� ����")]
        public string ResponsiblePerson { get; set; }
        [StringLength(100)]
        [Display(Name="Skype")]
        public string Skype { get; set; }
        [StringLength(100)]
        [Display(Name="Telegram")]
        public string Telegram { get; set; }
        [StringLength(20)]
        [Display(Name="����� ��������")]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        [Display(Name="������� �����")]
        public string WorkingTime { get; set; }

        [Display(Name = "��������")]
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }

        [Display(Name = "�������")]
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }

        [Display(Name = "�������")]
        public virtual User Creator { get; set; }

        [Display(Name = "�������")]
        public virtual User Modifier { get; set; }
    }
}
