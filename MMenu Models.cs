using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed_Production.Models
{
    public class MMenu_Models
    {
        public int CompanyId { get; set; }
        public int MenuId { get; set; }
        public string Module { get; set; }
        public string MenuName { get; set; }
        public string ParentId { get; set; }
        public string AcFlag { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Tag { get; set; }
        public string EntryType { get; set; }
        public int INputFlag { get; set; }
    }
}
