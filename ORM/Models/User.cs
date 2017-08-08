using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ORM.Models
{
    public class User
    {
        public User()
        {
            this.Lots = new HashSet<Lot>();
            this.Comments = new HashSet<Comment>();
            this.Bids = new HashSet<Bid>();
            this.Purchases = new HashSet<Purchase>();
        }
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50), MinLength(4)]
        public string Name { get; set; }
        [Required, MaxLength(50), MinLength(4)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Column(TypeName="datetime2")]
        public DateTime CreationDate { get; set; }
        public int? RoleId { get; set; }
        public virtual ICollection<Lot> Lots { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
