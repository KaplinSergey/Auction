using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your e-mail")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "The email must be 4 to 50 characters")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email")]
        public string Email { get; set; }       

        [Required(ErrorMessage = "The field can not be empty!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "The name must be 4 to 50 characters")]
        [Display(Name = "Enter your name")]
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
    }
}