using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCodeFirstProject__Elias.Models
{
    public class Book
    {
        public int BookID { get; set; }
        [Required(ErrorMessage = "Must be filled")]
        public string BookName { get; set; }
        [Required(ErrorMessage = "Must be filled")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Must be filled")]
        [Display(Name = "Borrow Date ")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime BorrowDate { get; set; }
        [Required(ErrorMessage = "Must be filled")]
        [Display(Name = "Photo ")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}