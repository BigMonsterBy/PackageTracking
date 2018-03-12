using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PackageTracking.Web.Models
{
    public class LogonViewModel
    {
        [Required]
        [MaxLength(250)]
        [Display(Name = "Пользователь")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        public int UserTimeOffset { get; set; }
    }
}