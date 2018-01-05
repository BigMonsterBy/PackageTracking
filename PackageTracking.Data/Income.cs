using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.Data
{
    [Serializable]
    public partial class Income
    {
        //MARK THE PRIMARY KEY!!!
        public Income()
        {
            Details = new List<Detail>();
        }

        public short IncomeID { get; set; }
        public DateTime IncomeDate { get; set; }
        public string Number { get; set; }
        public int Workshop { get; set; }
        public DateTime? LastEditDate { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<Detail> Details { get; set; }
    }
}
