using PackageTracking.Data.DAL;
using System;
using System.Collections.Generic;

namespace PackageTracking.Data.DTO
{
    [Serializable]
    public class ShipDTO
    {
        #region constructor
        //MARK THE PRIMARY KEY!!!
        public ShipDTO(Ship ship)
        {
            Number = ship.Number;
            ShipID = ship.ShipID;
            SDate = ship.SDate;
            Note = ship.Note;
            State = ship.State;
            Closed = ship.Closed;
            LastEditDate = ship.LastEditDate;
            CreationDate = ship.CreationDate;
            Rowguid = ship.Rowguid;
            SUID = ship.SUID;
            ShipFromSborka = ship.ShipFromSborka;
            ParentShipid = ship.ParentShipid;
            CreateUser = ship.CreateUser;
            LorryDateDeparture = ship.LorryDateDeparture;

            Orders = new List<OrderDTO>();

        }

        public ShipDTO()
        {
            Orders = new List<OrderDTO>();
        }

        #endregion
        #region fields

        public string Number { get; set; }
        public int ShipID { get; set; }
        public System.DateTime SDate { get; set; }
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

        public ICollection<OrderDTO> Orders { get; set; }

        #endregion
    }
}