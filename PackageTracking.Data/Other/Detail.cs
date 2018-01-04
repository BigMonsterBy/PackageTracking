using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.Data.Other
{
    [Serializable]
    public class Detail
    {
        //MARK THE PRIMARY KEY!!!
        public int DetailId { get; set; }
        public int IncomeId { get; set; }
        public string Customer { get; set; }
        public string Number { get; set; }
        public string ColorName { get; set; }
        public string ArticleName { get; set; }
        public int Qty { get; set; }
        public int Gtin { get; set; }
        public int Serial { get; set; }
        public DateTime LastEditDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string ForeignId { get; set; }
        public int Status { get; set; }
        public string Pallet { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Texture { get; set; }
        public string Edge { get; set; }
        public int Taping { get; set; }
        public string Rounding { get; set; }
        public int Thickness { get; set; }
        public string EdgeName { get; set; }
        public string Legs { get; set; }
        public string Note { get; set; }
        public int FrezR { get; set; }
        public string Shape { get; set; }
        public int CathetusL { get; set; }
        public int CathetusW { get; set; }
        public int Waterproof { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public DateTime StatusModfiedDate { get; set; }
        public DateTime AcceptDate { get; set; }
    }
}
