using System;
using System.Collections.Generic;
using BLL.Interfaces.Services;
using BLL.Interfaces.Entities;
using BLL.Mappers;
using DAL.Interfaces.Interfaces;
using System.Linq;

namespace BLL.Services
{
    public class BidService:IBidService
    {
        private readonly IUnitOfWork uow;
        private readonly IBidRepository bidRepository;
        public BidService(IUnitOfWork uow, IBidRepository repository)
        {
            this.uow = uow;
            this.bidRepository = repository;
        }

        public BidEntity GetBidEntity(int id)
        {
            return bidRepository.GetById(id).ToBllBid();
        }

        public IEnumerable<BidEntity> GetAllBidEntities()
        {
            return bidRepository.GetAll().Select(bid => bid.ToBllBid());
        }

        public IEnumerable<BidEntity> GetAllBidEntitiesByLotId(int id)
        {
            return GetAllBidEntities().Where(b => b.LotId == id);
        }

        public IEnumerable<BidEntity> GetAllBidEntitiesForSaleLots()
        {
            return GetAllBidEntities().Where(b => b.Lot.State==LotStateEntity.ForSale);
        }

        public void CreateBid(BidEntity bid)
        {
            bidRepository.Create(bid.ToDalBid());
            uow.Commit();
        }

        public bool TryCreateBid(BidEntity bid, LotEntity lot)
        {
            if (lot.UserId == bid.UserId || DateTime.Now >= (lot.StartDate + new TimeSpan(lot.Duration, 0, 0, 0)))
            {
                return false;
            }
            CreateBid(bid);
            return true;
        }

        public void DeleteBid(BidEntity bid)
        {
            bidRepository.Delete(bid.ToDalBid());
            uow.Commit();
        }

        public void UpdateBid(BidEntity bid)
        {
            bidRepository.Update(bid.ToDalBid());
            uow.Commit();
        }

        public bool ValidateBidPrice(BidEntity bid, LotEntity lot)
        {
            return bid.Price > lot.LastPrice;
        }

    }
}
