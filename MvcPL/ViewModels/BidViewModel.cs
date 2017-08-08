using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class BidViewModel
    {
        public int Id { get; set; }

        [Range(0, 10000)]
        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Make your bid in byn")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string LotName { get; set; }
        public int? LotId { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set;}
    }
}