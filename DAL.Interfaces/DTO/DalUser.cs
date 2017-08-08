using System;
using System.Collections.Generic;

namespace DAL.Interfaces.DTO
{
    public class DalUser:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public int? RoleId { get; set; }
        public IEnumerable<DalLot> Lots { get; set; }
        public IEnumerable<DalComment> Comments { get; set; }
        public IEnumerable<DalBid> Bids { get; set; }
        public IEnumerable<DalPurchase> Purchases { get; set; }
        public DalRole Role { get; set; }
    }
}
