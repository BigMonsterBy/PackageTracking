using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.Data
{
    [Serializable]
    public partial class Article
    {
        //MARK THE PRIMARY KEY!!!
        public Article()
        {
            Pack = new List<Pack>();
        }

        public string Type { get; set; }
        public int GTIN { get; set; }
        public int ColorID { get; set; }
        public string AName { get; set; }
        public int Category { get; set; }
        public int? Weigth { get; set; }
        public string GOST { get; set; }
        public string SName { get; set; }
        public int? PicID { get; set; }
        public string KitName { get; set; }
        public string ProjectName { get; set; }
        public string Producer { get; set; }
        public string Project { get; set; }
        public DateTime? LastEditDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid Rowguid { get; set; }
        public string ANameLong { get; set; }
        public bool? IsDOP { get; set; }
        public string LabelName { get; set; }
        public virtual ICollection<Pack> Pack { get; set; }
    }
}
