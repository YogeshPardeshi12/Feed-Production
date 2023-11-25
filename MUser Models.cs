using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed_Production.Models
{
    public class MUser_Models
    {
        public int CompanyId { get; set; }
        public string Module { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string UserType { get; set; }
        public string AcFlag { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string EntryType { get; set; }
        public int INputFlag { get; set; }
    }
}
