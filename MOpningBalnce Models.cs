using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed_Production.Models
{
    public class MOpningBalnce_Models
    {
        public int TID { get; set; }
        public int CompanyId { get; set; }
        public string Module { get; set; }
        public string TCode { get; set; }
        public int CustomerId { get; set; }
        public string AcType { get; set; }
        public string FYear { get; set; }
        public decimal OpeningBal { get; set; }
        public string AcFlag { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Remark { get; set; }
        public int ProductTypeId { get; set; }
        public string EntryType { get; set; }
        public int INputFlag { get; set; }
    }
}
