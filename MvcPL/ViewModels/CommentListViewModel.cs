using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class CommentListViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public int LotId { get; set; }
        [Required(ErrorMessage = "The field can not be empty!"), MaxLength(500)]
        [Display(Name = "Add your commentary")]
        public string Text { get; set; }
    }
}