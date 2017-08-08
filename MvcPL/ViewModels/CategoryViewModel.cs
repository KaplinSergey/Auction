using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The field can not be empty!"), MaxLength(50), MinLength(4)]
        [Display(Name = "Enter category name")]
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }
    }
}