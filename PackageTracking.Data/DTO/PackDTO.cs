using System;
using System.Collections.Generic;

namespace PackageTracking.Data.DTO
{
    [Serializable]
    public class PackDTO
    {
        #region constructor

        //MARK THE PRIMARY KEY!!!

        public PackDTO(Pack pack)
        {
            Serial = pack.Serial;
            GTIN = pack.GTIN;
            TaskID = pack.TaskID;
            OrderID = pack.OrderID;
            RegTime = pack.RegTime;
            RegBy = pack.RegBy;
            RegAuto = pack.RegAuto;
            ShippedTime = pack.ShippedTime;
            ShippedBy = pack.ShippedBy;
            ShippedAuto = pack.ShippedAuto;
            AddedBy = pack.AddedBy;
            AddedTime = pack.AddedTime;
            STo = pack.STo;
            RTo = pack.RTo;
            ITime = pack.ITime;
            Inv = pack.Inv;
            LastEditDate = pack.LastEditDate;
            Rowguid = pack.Rowguid;
            OIDAddedTime = pack.OIDAddedTime;
            Isprinted = pack.Isprinted;
            DriverShip = pack.DriverShip;
            DriverShipDate = pack.DriverShipDate;
            IsSended = pack.IsSended;
            IsInsight = pack.IsInsight;
            IsInsightPacked = pack.IsInsightPacked;
            IsInsightShipped = pack.IsInsightShipped;
            InsightCONid = pack.InsightCONid;
            AcceptedAuto = pack.AcceptedAuto;
            AcceptedBy = pack.AcceptedBy;
            AcceptedTime = pack.AcceptedTime;

            Details = new List<DetailDTO>();

        }

        public PackDTO()
        {
            Details = new List<DetailDTO>();
        }

        #endregion
        #region fields

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

        public virtual ICollection<DetailDTO> Details { get; set; }

        #endregion
    }
}