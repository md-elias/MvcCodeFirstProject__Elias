using MvcCodeFirstProject__Elias.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCodeFirstProject__Elias.Models
{
   
    public partial class Employee
    {
        public int EmployeeID { get; set; }
        [NvitValidation]
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Must Be Filled")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string Name { get; set; }

        [Display(Name = "Employee Age")]
        [Required(ErrorMessage = "Must Be Filled")]
        [Range(18, 60, ErrorMessage = "Age must be 18 to 60 year")]
        public int Age { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Must Be Filled")]
        [EmailAddress]
        public string Email { get; set; }
        public string Department { get; set; }

        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "Must Be Filled")]
        public int Phone { get; set; }

        [Display(Name = "Permanent Address")]
        [Required(ErrorMessage = "Must Be Filled")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Joining Date")]
        [Required(ErrorMessage = "Must Be Filled")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]

        [DataType(DataType.DateTime)]
        [CustomHireDate(ErrorMessage = "Hire Date must be less than or equal to Today's Date")]
        public DateTime JoiningDate { get; set; }

        
        [Required(ErrorMessage = "Must Be Filled")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(\S)+", ErrorMessage = "Whitespace not Allowed in Password")]
        public string Password { get; set; }

        
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Must Be Filled")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Must be matched with password")]
        public string ConfirmPassword { get; set; }


    }
}
