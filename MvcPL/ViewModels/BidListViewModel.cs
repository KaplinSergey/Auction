using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class BidListViewModel
    {
        public IEnumerable<BidViewModel> Bids { get; set; }
        public int LotId { get; set; }
        [Range(0, 10000)]
        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Make your bid in byn")]
        public decimal Price { get; set; }
    }
}