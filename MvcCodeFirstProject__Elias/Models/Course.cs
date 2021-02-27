using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcCodeFirstProject__Elias.Models
{
  

    public partial class Course
    {
       
        [Key]
        public int CourseID { get; set; }


        [Display(Name = "Course Name")]
        [Required(ErrorMessage = "Must Be Filled")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string CourseName { get; set; }

        [Display(Name = "Course Duration")]
        [Required(ErrorMessage = "Must Be Filled")]
        public string CourseDuration { get; set; }
        public virtual ICollection<Trainee> Trainees { get; set; }
    }
}
