using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCodeFirstProject__Elias.ViewModels
{
    public class BookVM
    {
        public int BookID { get; set; }
        [Required(ErrorMessage = "Must be filled")]        
        public string BookName { get; set; }
        [Required(ErrorMessage = "Must be filled")]
        [Display(Name = "Author Name :")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Must be filled")]
        [Display(Name = "Borrow Date ")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime BorrowDate { get; set; }

        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}