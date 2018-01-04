using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.Data.DTO
{
    [Serializable]
    public class IncomeDTO
    {
        //MARK THE PRIMARY KEY!!!
        #region constructor
        public IncomeDTO()
        {
            Details = new List<DetailDTO>();
        }

        #endregion

        #region fields
        public short IncomeID { get; set; }
        public DateTime IncomeDate { get; set; }
        public string Number { get; set; }
        public int Workshop { get; set; }
        public DateTime? LastEditDate { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<DetailDTO> Details { get; set; }

        #endregion


    }
}
