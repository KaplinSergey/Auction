using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ORM.Models
{
    public class Category
    {
        public Category()
        {
            this.Lots = new HashSet<Lot>();
        }
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50), MinLength(4)]
        public string Name { get; set; }
        [Required]
        public byte[] ImageData { get; set; }
        [Required, MaxLength(20)]
        public string ImageType { get; set; }
        public virtual ICollection<Lot> Lots { get; set; }
    }
}
