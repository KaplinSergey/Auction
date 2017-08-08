using System;
using System.Collections.Generic;

namespace DAL.Interfaces.DTO
{
    public class DalLot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal StartPrice { get; set; }
        public decimal? LastPrice { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }
        public DalLotState State { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
        public DalUser User { get; set; }
        public DalCategory Category { get; set; }
        public IEnumerable<DalComment> Comments { get; set; }
        public IEnumerable<DalBid> Bids { get; set; }
    }
}
