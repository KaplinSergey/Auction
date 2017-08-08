using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WpfPL.ViewModels
{
    public class LotViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The field can not be empty!"), MaxLength(50), MinLength(4)]
        [Display(Name = "Enter lot name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The field can not be empty!"), Range(0, 10000)]
        [Display(Name = "Enter start price of your lot")]
        public decimal StartPrice { get; set; }
        public decimal? LastPrice { get; set; }
        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter description of your lot")]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "The field can not be empty!"), Range(0, 30)]
        [Display(Name = "Enter duration of your lot")]
        public int Duration { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }
        public LotStateViewModel State { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
        public string OwnerName { get; set; }

        public TimeSpan TimeUntilEnd
        {
            get
            {
                return (StartDate + new TimeSpan(Duration, 0, 0, 0)) > DateTime.Now ? (StartDate + new TimeSpan(Duration, 0, 0, 0)) - DateTime.Now : new TimeSpan(0, 0, 0, 0);
            }
        }
        public decimal CurrentPrice
        {
            get
            {
                return LastPrice ?? StartPrice;
            }
        }
    }
}
