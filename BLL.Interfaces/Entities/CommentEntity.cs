using System;
using System.Collections.Generic;


namespace BLL.Interfaces.Entities
{
    public class CommentEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int? LotId { get; set; }
        public int? UserId { get; set; }
        public UserEntity User { get; set; }
        public LotEntity Lot { get; set; }
    }
}
