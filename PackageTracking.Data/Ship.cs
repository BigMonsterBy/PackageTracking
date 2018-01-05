using PackageTracking.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.Data
{
    [Serializable]
    public class Ship : IAuditable
    {
        public Ship()
        {
            Orders = new List<Order>();
        }

        [Key]
        public int ShipID { get; set; }
        public string Number { get; set; }
        public DateTime SDate { get; set; }
        public string Note { get; set; }
        public int State { get; set; }
        public DateTime? Closed { get; set; }
        public DateTime? LastEditDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid Rowguid { get; set; }
        public string SUID { get; set; }
        public bool? ShipFromSborka { get; set; }
        public int? ParentShipid { get; set; }
        public string CreateUser { get; set; }
        public DateTime? LorryDateDeparture { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
    }
}
