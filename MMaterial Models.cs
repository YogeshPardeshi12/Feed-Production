using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed_Production.Models
{
    public class MMaterial_Models
    {
        public int MaterialId { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public int MatrialUnit { get; set; }
        public int PackingId { get; set; }
        public string ForCasteFlag { get; set; }
        public string AcFlag { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Remark { get; set; }
        public string EntryType { get; set; }
        public int INputFlag { get; set; }

    }
}
