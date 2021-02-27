using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace MvcCodeFirstProject__Elias.Models
{
  

    public partial class Consultant
    {

        public int ConsultantID { get; set; }

        [Display(Name = "Consultant Name")]
        [Required(ErrorMessage = "Must Be Filled")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string Name { get; set; }

        [Display(Name = "Position")]
        [Required(ErrorMessage = "Must Be Filled")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Must Be Filled")]
        public string Office { get; set; }

        [Display(Name = "Salary")]
        [Required(ErrorMessage = "Must Be Filled")]
        [Range(9999, 50000, ErrorMessage = "Salary must be 9999 to 50000 year")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Must Be Filled")]
        [Display(Name = "Photo")]
        public string ImagePath { get; set; }


        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public Consultant()
        {
            ImagePath = "~/AppFiles/Images/default.png";
        }
    }
}
