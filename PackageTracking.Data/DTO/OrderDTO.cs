using PackageTracking.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.Data.DTO
{
    [Serializable]
    public class OrderDTO
    {
        #region constructor
        //MARK THE PRIMARY KEY!!!
        public OrderDTO(Orders order)
        {
            OrderID = order.OrderID;
            GTIN = order.GTIN;
            ShipID = order.ShipID;
            Customer = order.Customer;
            Number = order.Number;
            Qty = order.Qty;
            Note = order.Note;
            AddedBy = order.AddedBy;
            AddedTime = order.AddedTime;
            LastEditDate = order.LastEditDate;
            Rowguid = order.Rowguid;
            OUID = order.OUID;
            Replacemented = order.Replacemented;
            ProgPack = order.ProgPack;
            ProgPackStr = order.ProgPackStr;
            Is2020 = order.Is2020;
            ForeignOrderId = order.ForeignOrderId;
            OrderOUID = order.OrderOUID;
            From2020 = order.From2020;
            Ispacked = order.Ispacked;
            ForeignOrderId_int = order.ForeignOrderId_int;
            ShipOrderID = order.ShipOrderID;

            Packs = new List<PackDTO>();
        }

        public OrderDTO()
        {
            Packs = new List<PackDTO>();
        }

        #endregion
        #region fields

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

        public ShipDTO Ship { get; set; }
        public ICollection<PackDTO> Packs { get; set; }

        #endregion
    }
}
