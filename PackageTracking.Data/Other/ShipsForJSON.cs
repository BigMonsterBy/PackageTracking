using PackageTracking.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.Data.Other
{
    public class ShipsForJSON
    {
        #region constructor

        public ShipsForJSON()
        {
            Ships = new List<ShipDTO>();
        }

        #endregion
        #region fields

        public List<ShipDTO> Ships { get; set; }
        public string DriverName { get; set; }
        public string DeliveryCar { get; set; }

        #endregion
    }
}
