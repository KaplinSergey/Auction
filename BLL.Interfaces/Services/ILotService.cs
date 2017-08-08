using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface ILotService
    {
        LotEntity GetLotEntity(int id);
        IEnumerable<LotEntity> GetAllLotEntities();
        IEnumerable<LotEntity> GetAllForSaleLotEntities();
        void CreateLot(LotEntity lot);
        void DeleteLot(LotEntity lot);
        void UpdateLot(LotEntity lot);
        void CheckAllLotEntities();
        bool TryUpdateLot(LotEntity lot);
        UserEntity GetMaxBidOwner(LotEntity lot);
    }
}
