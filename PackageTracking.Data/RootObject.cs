using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.Data
{
    public class Rootobject
    {
        [Key]
        public int Key { get; set; }
        public virtual ICollection<Ship> Ships { get; set; }
        public string DriverName { get; set; }
        public string DeliveryCar { get; set; }
        public Rootobject()
        {
            Ships = new List<Ship>();
        }
    }
}
