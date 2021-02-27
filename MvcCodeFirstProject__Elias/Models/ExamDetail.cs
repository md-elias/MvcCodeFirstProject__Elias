using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCodeFirstProject__Elias.Models
{


    public partial class ExamDetail
    {
        [Key]
        public int ExamDetailID { get; set; }


        [Display(Name = "Exam Name")]
        [Required(ErrorMessage = "Must Be Filled")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string ExamName { get; set; }


        public int StudentId { get; set; }


        [Display(Name = "Exam Date ")]
        [Required(ErrorMessage = "Must Be Filled")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ExamDate { get; set; }

        [Display(Name = "Result Published Date ")]
        [Required(ErrorMessage = "Must Be Filled")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ResultPublishDate { get; set; }


        [Required(ErrorMessage = "Must Be Filled")]
        public int MCQ { get; set; }

        [Required(ErrorMessage = "Must Be Filled")]

        public int Descriptive { get; set; }

        [Required(ErrorMessage = "Must Be Filled")]

        public int Evidence { get; set; }
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal TotalMarks { get { return (MCQ + Descriptive + Evidence); } }

        public virtual Student Students { get; set; }
    }
}
