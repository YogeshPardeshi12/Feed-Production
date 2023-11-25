using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed_Production.Models
{
    public class Customer_Models
    {
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }  
        public string BrokeragePer { get; set; }
        [Required(ErrorMessage = "Please Enter Customer Name")]

        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string PhoneNo { get; set; }
        public string CellNo { get; set; }
        public int BankId { get; set; }
        public string AccountNo { get; set; }
        public string IFSCCode { get; set; }
        public string VATNo { get; set; }
        public string CSTNo { get; set; }
        public string BSTNo { get; set; }
        public string PANNo { get; set; }
        public string TANNo { get; set; }
        public string EmailId { get; set; }
        public string FAXNo { get; set; }
        public string ContactPerson { get; set; }
        public string AcFlag { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Remark { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string BankAddress { get; set; }
        public string EntryType { get; set; }
        public int INputFlag { get; set; }
        public string flag { get; set; }
    }
}
