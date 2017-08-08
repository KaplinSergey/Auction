using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class PurchaseViewModel
    {
            public int Id { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
            public DateTime Date { get; set; }
            public int? LotId { get; set; }
            public int? UserId { get; set; }
            public string LotName { get; set; }
            public string Description { get; set; }
            public decimal StartPrice { get; set; }
            public decimal PurchasePrice { get; set; }
    }
}