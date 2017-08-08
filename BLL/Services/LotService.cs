using System;
using System.Collections.Generic;
using BLL.Interfaces.Services;
using BLL.Interfaces.Entities;
using BLL.Mappers;
using BLL.Extensions;
using DAL.Interfaces.Interfaces;
using System.Linq;


namespace BLL.Services
{
    public class LotService:ILotService
    {
        private readonly IUnitOfWork uow;
        private readonly ILotRepository lotRepository;
        private readonly IPurchaseRepository purchaseRepository;
        private static readonly object padlock = new object();

        public LotService(IUnitOfWork uow, ILotRepository repository, IPurchaseRepository purchaseRepository)
        {
            this.uow = uow;
            this.lotRepository = repository;
            this.purchaseRepository = purchaseRepository;
        }

        public LotEntity GetLotEntity(int id)
        {
            return lotRepository.GetById(id).ToBllLot();
        }

        public IEnumerable<LotEntity> GetAllLotEntities()
        {
            return lotRepository.GetAll().Select(lot => lot.ToBllLot());
        }

        public IEnumerable<LotEntity> GetAllForSaleLotEntities()
        {
            return lotRepository.GetAll().Where(lot=>lot.State==LotStateEntity.ForSale.ToDalLotState()).Select(lot => lot.ToBllLot());
        }

        /// <summary>
        /// Check all lots for sale at the end of the trading period and sends a letter to the seller and the customer
        /// </summary>
        public void CheckAllLotEntities()
        {
            lock (padlock)
            {
                IEnumerable<LotEntity> lots = GetAllForSaleLotEntities().Where(lot => DateTime.Now >= (lot.StartDate + new TimeSpan(lot.Duration, 0, 0, 0)));
                if (lots != null)
                {
                    bool isEntryChanges = false;
                    foreach (var lot in lots)
                    {
                        if (lot.LastPrice != null)
                        {
                            lot.State = LotStateEntity.Sold;
                            string sellerMailSubject = "Your lot is sold";
                            string sellerMailBody = string.Format("Your lot {0} is sold for the {1} byn. Please come to the auction office for the completion of the sale transaction.", lot.Name, lot.LastPrice);
                            UserEntity seller = lot.User;
                            seller.SendMessage(sellerMailSubject, sellerMailBody);
                            string customerMailSubject = "You won the auction";
                            string customerMailBody = string.Format("You won lot {0} for the {1} byn. Please come to the auction office for the completion of the sale transaction.", lot.Name, lot.LastPrice);
                            UserEntity customer = GetMaxBidOwner(lot);
                            PurchaseEntity purchase = new PurchaseEntity { Lot = lot, LotId = lot.Id, User = customer, UserId = customer.Id, Date = DateTime.Now };
                            purchaseRepository.Create(purchase.ToDalPurchase());
                            customer.SendMessage(customerMailSubject, customerMailBody);
                        }
                        else
                        {
                            lot.State = LotStateEntity.Unsold;
                            string sellerMailSubject = "Your lot not sold";
                            string sellerMailBody = string.Format("Your lot {0} with the start price {1} byn not sold.", lot.Name, lot.StartPrice);
                            UserEntity seller = lot.User;
                            seller.SendMessage(sellerMailSubject, sellerMailBody);
                        }
                        lotRepository.Update(lot.ToDalLot());
                        isEntryChanges = true;
                    }
                    if (isEntryChanges)
                    {
                        uow.Commit();
                    }
                }
            }

        }

        public void CreateLot(LotEntity lot)
        {
            lotRepository.Create(lot.ToDalLot());
            uow.Commit();
        }

        public void DeleteLot(LotEntity lot)
        {
            lotRepository.Delete(lot.ToDalLot());
            uow.Commit();
        }

        public void UpdateLot(LotEntity lot)
        {
            lotRepository.Update(lot.ToDalLot());
            uow.Commit();
        }

        public bool TryUpdateLot(LotEntity lot)
        {
            if (GetLotEntity(lot.Id).State==LotStateEntity.Unsold)
            {
                UpdateLot(lot);
                return true;
            }
            else
            {
                return false;
            }
        }

        public UserEntity GetMaxBidOwner(LotEntity lot)
        {
            return lot.Bids.LastOrDefault(b => b.Date <= (lot.StartDate + new TimeSpan(lot.Duration, 0, 0, 0))).User;
        }

    }
}
