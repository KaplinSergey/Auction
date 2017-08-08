using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The field can not be empty!"), MaxLength(500)]
        [Display(Name = "Add your commentary")]
        public string Text { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int? LotId { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
    }
}