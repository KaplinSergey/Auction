using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface IBidService
    {
        BidEntity GetBidEntity(int id);
        IEnumerable<BidEntity> GetAllBidEntities();
        IEnumerable<BidEntity> GetAllBidEntitiesByLotId(int id);
        IEnumerable<BidEntity> GetAllBidEntitiesForSaleLots();
        bool TryCreateBid(BidEntity bid, LotEntity lot);
        void CreateBid(BidEntity bid);
        void DeleteBid(BidEntity bid);
        void UpdateBid(BidEntity bid);
        bool ValidateBidPrice(BidEntity bid, LotEntity lot);
    }
}
