using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed_Production.Models
{
    public class MSupplier_Models
    {
        public int SupplierId { get; set; }
        public string SupplierCode { get; set; }
        public string BrokeragePer { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string PhoneNo { get; set; }
        public string CellNo { get; set; }
        public string VATNo { get; set; }
        public string CSTNo { get; set; }
        public string BSTNo { get; set; }
        public string PANNo { get; set; }
        public string TANNo { get; set; }
        public string EmailId { get; set; }
        public string FAXNo { get; set; }
        public string AcFlag { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Remark { get; set; }
        public string AccountNo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string BankAddress { get; set; }
        public string EntryType { get; set; }
        public int INputFlag { get; set; }
    }
}
