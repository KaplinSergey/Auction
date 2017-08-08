using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface IExceptionInformationService
    {
        ExceptionInformationEntity GetExceptionInformationEntity(int id);
        IEnumerable<ExceptionInformationEntity> GetAllExceptionInformationEntities();
        void CreateExceptionInformation(ExceptionInformationEntity exceptionInformation);
        void DeleteExceptionInformation(ExceptionInformationEntity exceptionInformation);
        void UpdateExceptionInformation(ExceptionInformationEntity exceptionInformation); 
    }
}
