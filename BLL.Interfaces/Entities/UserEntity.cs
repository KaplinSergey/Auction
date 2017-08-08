using System;
using System.Collections.Generic;

namespace BLL.Interfaces.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public int? RoleId { get; set; }
        public IEnumerable<LotEntity> Lots { get; set; }
        public IEnumerable<CommentEntity> Comments { get; set; }
        public IEnumerable<BidEntity> Bids { get; set; }
        public IEnumerable<PurchaseEntity> Purchases { get; set; }
        public RoleEntity Role { get; set; }
    }
}
