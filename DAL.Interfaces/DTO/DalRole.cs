using System;
using System.Collections.Generic;

namespace DAL.Interfaces.DTO
{
    public class DalRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DalUser> Users { get; set; }
    }
}
