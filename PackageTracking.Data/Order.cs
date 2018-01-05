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
    public class Order : IAuditable
    {
        public Order()
        {
            Packs = new List<Pack>();
        }
        [Key]
        public int OrderID { get; set; }
        public int GTIN { get; set; }
        public int ShipID { get; set; }
        public string Customer { get; set; }
        public string Number { get; set; }
        public int Qty { get; set; }
        public string Note { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime? LastEditDate { get; set; }
        public Guid Rowguid { get; set; }
        public int? OUID { get; set; }
        public short? Replacemented { get; set; }
        public int? ProgPack { get; set; }
        public string ProgPackStr { get; set; }
        public short? Is2020 { get; set; }
        public string ForeignOrderId { get; set; }
        public string OrderOUID { get; set; }
        public int? From2020 { get; set; }
        public int? Ispacked { get; set; }
        public int? ForeignOrderId_int { get; set; }
        public int? ShipOrderID { get; set; }

        public virtual Ship Ship { get; set; }
        public virtual ICollection<Pack> Packs { get; set; }

        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
    }
}
