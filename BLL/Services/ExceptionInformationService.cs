using System;
using System.Collections.Generic;
using BLL.Interfaces.Services;
using BLL.Interfaces.Entities;
using BLL.Mappers;
using DAL.Interfaces.Interfaces;
using System.Linq;
namespace BLL.Services
{
    public class ExceptionInformationService:IExceptionInformationService
    {
        private readonly IUnitOfWork uow;
        private readonly IExceptionInformationRepository exceptionRepository;
        public ExceptionInformationService(IUnitOfWork uow, IExceptionInformationRepository repository)
        {
            this.uow = uow;
            this.exceptionRepository = repository;
        }
        public ExceptionInformationEntity GetExceptionInformationEntity(int id)
        {
            return exceptionRepository.GetById(id).ToBllExceptionInformation();
        }

        public IEnumerable<ExceptionInformationEntity> GetAllExceptionInformationEntities()
        {
            return exceptionRepository.GetAll().Select(exception => exception.ToBllExceptionInformation());
        }

        public void CreateExceptionInformation(ExceptionInformationEntity exceptionInformation)
        {
            exceptionRepository.Create(exceptionInformation.ToDalExceptionInformation());
            uow.Commit();
        }

        public void DeleteExceptionInformation(ExceptionInformationEntity exceptionInformation)
        {
            exceptionRepository.Delete(exceptionInformation.ToDalExceptionInformation());
            uow.Commit();
        }

        public void UpdateExceptionInformation(ExceptionInformationEntity exceptionInformation)
        {
            exceptionRepository.Update(exceptionInformation.ToDalExceptionInformation());
            uow.Commit();
        }
    }
}
