using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Models
{
    public class Lot
    {
        public Lot()
        {
            this.Comments = new HashSet<Comment>();
            this.Bids = new HashSet<Bid>();
        }
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50), MinLength(4)]
        public string Name { get; set; }
        [Required, Range(0, 10000)]
        public decimal StartPrice { get; set; }
        [Range(0, 10000)]
        public decimal? LastPrice { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }
        [Required, Range(0, 30)]
        public int Duration { get; set; }
        [Required]
        public byte[] ImageData { get; set; }
        [Required, MaxLength(20)]
        public string ImageType { get; set; }
        public LotState State { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }

    }
}
