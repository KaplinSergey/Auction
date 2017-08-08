using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ORM.Models
{
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50), MinLength(4)]
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
