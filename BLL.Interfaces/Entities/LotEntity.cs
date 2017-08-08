using System;
using System.Collections.Generic;


namespace BLL.Interfaces.Entities
{
    public class LotEntity
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
        public LotStateEntity State { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
        public UserEntity User { get; set; }
        public CategoryEntity Category { get; set; }
        public IEnumerable<CommentEntity> Comments { get; set; }
        public IEnumerable<BidEntity> Bids { get; set; }

    }
}
