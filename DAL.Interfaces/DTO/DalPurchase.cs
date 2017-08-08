using System;
using System.Collections.Generic;

namespace DAL.Interfaces.DTO
{
    public class DalPurchase:IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? LotId { get; set; }
        public int? UserId { get; set; }
        public DalUser User { get; set; }
        public DalLot Lot { get; set; }
    }
}
