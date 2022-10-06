using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFDBFirstApproachExample1.Models
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