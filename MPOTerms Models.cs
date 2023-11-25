using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed_Production.Models
{
    public class MPOTerms_Models
    {
        public int POtermsId { get; set; }
        public int CompanyId { get; set; }
        public string Module { get; set; }
        public string POtermsCode { get; set; }
        public string POtermsName { get; set; }
        public string Description { get; set; }
        public string AcFlag { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Remark { get; set; }
        public string EntryType { get; set; }
        public int INputFlag { get; set; }
    }
}
