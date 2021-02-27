using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcCodeFirstProject__Elias.Models
{


    public partial class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Must Be Filled")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string Name { get; set; }

        [Display(Name = "Core Subject")]
        [Required(ErrorMessage = "Must Be Filled")]
        public string CoreSubject { get; set; }

        [Display(Name = "Round No :")]
        [Required(ErrorMessage = "Must Be Filled")]
        public int Round { get; set; }

        [Display(Name = "TSP Info :")]
        [Required(ErrorMessage = "Must Be Filled")]
        public string TSP { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Must Be Filled")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Date Of Birth ")]
        [Required(ErrorMessage = "Must Be Filled")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

      
        public virtual ICollection<ExamDetail> ExamDetails { get; set; }
    }
}
