using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface IPurchaseService
    {
        PurchaseEntity GetPurchaseEntity(int id);
        IEnumerable<PurchaseEntity> GetAllPurchaseEntities();
        void CreatePurchase(PurchaseEntity purchase);
        void DeletePurchase(PurchaseEntity purchase);
        void UpdatePurchase(PurchaseEntity purchase);
        IEnumerable<PurchaseEntity> GetPurchasesByUserId(int userId);
    }
}
