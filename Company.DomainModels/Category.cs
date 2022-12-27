using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DomainModels
{
    public class Category
    {
        [Key]
        [Display(Name = "CategoryID")]
        public long CategoryID { get; set; }

        [Display(Name = "CategoryName")]
        public string CategoryName { get; set; }
    }
}
