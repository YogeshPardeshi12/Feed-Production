using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Feed_Production.Models
{
    public class Company_Models
    {
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        [Required(ErrorMessage ="Please Enter Company Name")]
        //[MinLength(2,ErrorMessage ="Minimum Enter 2 Number")]
        //[MaxLength(50,ErrorMessage ="Maximmum Enter 50 Number")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Please Enter Company Address")]
        //[MinLength(2, ErrorMessage = "Minimum Enter 2 Number")]
        //[MaxLength(50, ErrorMessage = "Maximmum Enter 50 Number")]
        public string CompanyAdddess { get; set; }
        //[Required(ErrorMessage = "Please Enter PhoneNo")]
        [MaxLength(50, ErrorMessage = "Maximmum Enter 10 Number")]
        public string PhoneNo { get; set; } 
        public string CellNo { get; set; }
        [Required(ErrorMessage = "Please Enter EmailId")]
        //[MinLength(2, ErrorMessage = "Minimum Enter 2 Number")]
        //[MaxLength(50, ErrorMessage = "Maximmum Enter 50 Number")]
        public string EmailId { get; set; }
        public string PANNo { get; set; }
        public string CST { get; set; }
        public string BST { get; set; }
        public string AcFlag { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Remark { get; set; }
        public string TallyId { get; set; }
        public string EntryType { get; set; }
        public int INputFlag { get; set; }




    }
}
