using System;

namespace PackageTracking.Data.DTO
{
    [Serializable]
    public class DetailDTO
    {
        #region constructor
        //MARK THE PRIMARY KEY!!!
        public DetailDTO(Detail detail)
        {
            DetailID = detail.DetailID;
            IncomeID = detail.IncomeID;
            Customer = detail.Customer;
            Number = detail.Number;
            ColorName = detail.ColorName;
            ArticleName = detail.ArticleName;
            Qty = detail.Qty;
            GTIN = detail.GTIN;
            Serial = detail.Serial;
            LastEditDate = detail.LastEditDate;
            CreationDate = detail.CreationDate;
            ForeignID = detail.ForeignID;
            Status = detail.Status;
            Pallet = detail.Pallet;
            Length = detail.Length;
            Width = detail.Width;
            Texture = detail.Texture;
            Edge = detail.Edge;
            Taping = detail.Taping;
            Rounding = detail.Rounding;
            Thickness = detail.Thickness;
            EdgeName = detail.EdgeName;
            Legs = detail.Legs;
            Note = detail.Note;
            FrezR = detail.FrezR;
            Shape = detail.Shape;
            CathetusL = detail.CathetusL;
            CathetusW = detail.CathetusW;
            Waterproof = detail.Waterproof;
            X = detail.X;
            Y = detail.Y;
            StatusModfiedDate = detail.StatusModfiedDate;
            AcceptDate = detail.AcceptDate;
        }

        public DetailDTO()
        {

        }

        #endregion
        #region fields

        public int DetailID { get; set; }
        public short IncomeID { get; set; }
        public string Customer { get; set; }
        public string Number { get; set; }
        public string ColorName { get; set; }
        public string ArticleName { get; set; }
        public short Qty { get; set; }
        public int GTIN { get; set; }
        public int? Serial { get; set; }
        public DateTime? LastEditDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ForeignID { get; set; }
        public byte? Status { get; set; }
        public string Pallet { get; set; }
        public short? Length { get; set; }
        public short? Width { get; set; }
        public byte? Texture { get; set; }
        public string Edge { get; set; }
        public byte? Taping { get; set; }
        public string Rounding { get; set; }
        public byte? Thickness { get; set; }
        public string EdgeName { get; set; }
        public string Legs { get; set; }
        public string Note { get; set; }
        public short? FrezR { get; set; }
        public string Shape { get; set; }
        public short? CathetusL { get; set; }
        public short? CathetusW { get; set; }
        public short? Waterproof { get; set; }
        public float? X { get; set; }
        public float? Y { get; set; }
        public DateTime? StatusModfiedDate { get; set; }
        public DateTime? AcceptDate { get; set; }

        public IncomeDTO Income { get; set; }

        #endregion

    }
}
