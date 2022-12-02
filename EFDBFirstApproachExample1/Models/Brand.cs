using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EFDBFirstApproachExample1.Models
{
    public class Brand
    {

        [Key]
        [Display(Name = "BrandID")]
        public long BrandID { get; set; }

        [Display(Name = "BrandName")]
        public string BrandName { get; set; }
    }
}