using System;
using System.ComponentModel.DataAnnotations;

namespace PackageTracking.Data
{
    [Serializable]
    public class Detail
    {
        [Key]
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

        public virtual Income Income { get; set; }
        public virtual Pack Pack { get; set; }

        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
    }
}
