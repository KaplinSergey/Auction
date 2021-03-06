﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        public int? LotId { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("LotId")]
        public virtual Lot Lot { get; set; }
    }
}
