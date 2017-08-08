using System;
using System.Collections.Generic;
using BLL.Interfaces.Services;
using BLL.Interfaces.Entities;
using BLL.Mappers;
using DAL.Interfaces.Interfaces;
using System.Linq;

namespace BLL.Services
{
    public class PurchaseService:IPurchaseService
    {
        private readonly IUnitOfWork uow;
        private readonly IPurchaseRepository purchaseRepository;
        public PurchaseService(IUnitOfWork uow, IPurchaseRepository repository)
        {
            this.uow = uow;
            this.purchaseRepository = repository;
        }
        public PurchaseEntity GetPurchaseEntity(int id)
        {
            return purchaseRepository.GetById(id).ToBllPurchase();
        }

        public IEnumerable<PurchaseEntity> GetAllPurchaseEntities()
        {
            return purchaseRepository.GetAll().Select(purchase => purchase.ToBllPurchase());
        }

        public void CreatePurchase(PurchaseEntity purchase)
        {
            purchaseRepository.Create(purchase.ToDalPurchase());
            uow.Commit();
        }

        public void DeletePurchase(PurchaseEntity purchase)
        {
            purchaseRepository.Delete(purchase.ToDalPurchase());
            uow.Commit();
        }

        public void UpdatePurchase(PurchaseEntity purchase)
        {
            purchaseRepository.Update(purchase.ToDalPurchase());
            uow.Commit();
        }

        public IEnumerable<PurchaseEntity> GetPurchasesByUserId(int userId)
        {
            return purchaseRepository.GetAll().Where(p => p.User.Id == userId).Select(p=>p.ToBllPurchase());
        }
    }
}
