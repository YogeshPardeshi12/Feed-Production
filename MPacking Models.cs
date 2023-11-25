using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed_Production.Models
{
    public class MPacking_Models
    {
        public int PackingId { get; set; }
        public string PackingCode { get; set; }
        public string PackingName { get; set; }
        public string AcFlag { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Remark { get; set; }
        public string EntryType { get; set; }
        public int INputFlag { get; set; }
    }
}
