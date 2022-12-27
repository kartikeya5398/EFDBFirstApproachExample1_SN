using Company.DomainModels.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DomainModels
{
    public class Product
    {
        [Key]
        [Display(Name = "ProductID")]

        public long ProductID { get; set; }

        [Display(Name = "ProductName")]
        [Required(ErrorMessage = "Product Name Required")]
        //[RegularExpression(@"^[A-Za-z0-9 ]*$", ErrorMessage = "Alphabets Only")]
        [MaxLength(50, ErrorMessage = "Product Name should not be more than 50 Characters")]
        [MinLength(2, ErrorMessage = "Product Name contains at least 2 characters")]
        public string ProductName { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price must be Required")]
        [Range(0, 100000, ErrorMessage = "Price should be in between 0 and 100000")]
        [DivisibleBy10(ErrorMessage = "Price should be in Multiple of 10")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "Date Of Purchase")]
        //[Required(ErrorMessage = "Date Of Purchase Required")]
        [Column("DateOfPurchase", TypeName = "datetime")]
        //[DisplayFormat(DataFormatString = "d/M/yyyy", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }

        [Display(Name = "Availability Status")]
        [Required(ErrorMessage = "Please Select AvailabilityStatus")]
        public string AvailabilityStatus { get; set; }

        [Display(Name = "CategoryID")]
        [Required(ErrorMessage = "CategoryID Required")]
        public Nullable<long> CategoryID { get; set; }

        [Display(Name = "BrandID")]
        [Required(ErrorMessage = "BrandID Required")]
        public Nullable<long> BrandID { get; set; }

        [Display(Name = "Active")]
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> quantity { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }

}
