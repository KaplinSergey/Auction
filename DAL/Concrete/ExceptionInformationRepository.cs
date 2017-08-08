using DAL.Interfaces.Interfaces;
using DAL.Interfaces.DTO;
using DAL.Interfaces;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using ORM.Models;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class ExceptionInformationRepository:IExceptionInformationRepository
    {
        private readonly DbContext _context;

        public ExceptionInformationRepository(DbContext uow)
        {
            this._context = uow;
        }
        public IEnumerable<DalExceptionInformation> GetAll()
        {
            return _context.Set<ExceptionInformation>().ToList().Select(exception => exception.ToDalExceptionInformation());
        }

        public DalExceptionInformation GetById(int key)
        {
            return _context.Set<ExceptionInformation>().FirstOrDefault(exception => exception.Id == key).ToDalExceptionInformation();
        }

        public DalExceptionInformation GetByPredicate(Expression<Func<DalExceptionInformation, bool>> predicate)
        {
            var newExpression = ExpressionConverter.Convert<DalExceptionInformation, ExceptionInformation>(predicate);
            var exeption = _context.Set<ExceptionInformation>().FirstOrDefault(newExpression);
            return exeption.ToDalExceptionInformation();
        }

        public void Create(DalExceptionInformation entity)
        {
            _context.Set<ExceptionInformation>().Add(entity.ToOrmExceptionInformation());
        }

        public void Delete(DalExceptionInformation entity)
        {
            var exeption = _context.Set<ExceptionInformation>().Single(e => e.Id == entity.Id);
            _context.Set<ExceptionInformation>().Remove(entity.ToOrmExceptionInformation());
        }

        public void Update(DalExceptionInformation entity)
        {
            _context.Set<ExceptionInformation>().AddOrUpdate(entity.ToOrmExceptionInformation());
        }
    }
}
