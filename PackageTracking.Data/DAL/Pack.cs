using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.Data.DAL
{
    [Serializable]
    public partial class Pack
    {
        //MARK THE PRIMARY KEY!!!
        public int Serial { get; set; }
        public int GTIN { get; set; }
        public int TaskID { get; set; }
        public int? OrderID { get; set; }
        public DateTime? RegTime { get; set; }
        public string RegBy { get; set; }
        public bool? RegAuto { get; set; }
        public DateTime? ShippedTime { get; set; }
        public string ShippedBy { get; set; }
        public bool? ShippedAuto { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedTime { get; set; }
        public byte? STo { get; set; }
        public byte? RTo { get; set; }
        public DateTime? ITime { get; set; }
        public bool? Inv { get; set; }
        public DateTime? LastEditDate { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime? OIDAddedTime { get; set; }
        public int? Isprinted { get; set; }
        public int? DriverShip { get; set; }
        public DateTime? DriverShipDate { get; set; }
        public bool? IsSended { get; set; }
        public bool? IsInsight { get; set; }
        public bool? IsInsightPacked { get; set; }
        public bool? IsInsightShipped { get; set; }
        public int? InsightCONid { get; set; }
        public bool? AcceptedAuto { get; set; }
        public string AcceptedBy { get; set; }
        public DateTime? AcceptedTime { get; set; }

        public virtual Article Article { get; set; }
        public virtual Orders Orders { get; set; }
    }
}
