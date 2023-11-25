using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed_Production.Models
{
    public class MExpenses_Models
    {
        public int ExpenseId { get; set; }
        public int CompanyId { get; set; }
        public string Module { get; set; }
        public string ExpenseCode { get; set; }
        public string ExpenseName { get; set; }
        public string Specification { get; set; }
        public decimal MaxLimit { get; set; }
        public string AcFlag { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Remark { get; set; }
        public string ProductionFlag { get; set; }
        public string BatchExpense { get; set; }
        public string EntryType { get; set; }
        public int INputFlag { get; set; }
        public string flag { get; set; }
    }
}
