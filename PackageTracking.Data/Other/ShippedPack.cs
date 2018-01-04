using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.Data.Other
{
    [Serializable]
    public class ShippedPack
    {
        //MARK THE PRIMARY KEY!!!
        public DateTime ShipDate { get; set; } //SDate
        public string ShipNumber { get; set; } //s_num
        public string Note { get; set; }
        public DateTime Closed { get; set; }
        public string Customer { get; set; }
        public string OrderNumber { get; set; }
        public string ColorName { get; set; }
        public string ArticleName { get; set; }
        public int Serial { get; set; }
        public DateTime RegTime { get; set; }
        public string RegBy { get; set; }
        public bool RegAuto { get; set; }
        public DateTime ShippedTime { get; set; }
        public string ShippedBy { get; set; }
        public string AddedBy { get; set; }
        public int DriverShip { get; set; }
        public DateTime DriverShipDate { get; set; }
    }
}
