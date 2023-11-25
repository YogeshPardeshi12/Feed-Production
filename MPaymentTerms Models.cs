using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed_Production.Models
{
    public class MPaymentTerms_Models
    {
        public int PaymentTermId { get; set; }
        public string PaymentTermCode { get; set; }
        public string PaymentTermDescription { get; set; }
        public string Days { get; set; }
        public string AcFlag { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Remarks { get; set; }
        public string EntryType { get; set; }
        public int INputFlag { get; set; }
    }
}
