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
    public class PurchaseRepository:IPurchaseRepository
    {
        private readonly DbContext _context;

        public PurchaseRepository(DbContext uow)
        {
            this._context = uow;
        }

        public IEnumerable<DalPurchase> GetAll()
        {
            return _context.Set<Purchase>().ToList().Select(purchase => purchase.ToDalPurchase());
        }

        public DalPurchase GetById(int key)
        {
            return _context.Set<Purchase>().FirstOrDefault(purchase => purchase.Id == key).ToDalPurchase();
        }

        public DalPurchase GetByPredicate(Expression<Func<DalPurchase, bool>> predicate)
        {
            var newExpression = ExpressionConverter.Convert<DalPurchase, Purchase>(predicate);
            var purchase = _context.Set<Purchase>().FirstOrDefault(newExpression);
            return purchase.ToDalPurchase();
        }

        public void Create(DalPurchase entity)
        {
            _context.Set<Purchase>().Add(entity.ToOrmPurchase());
        }

        public void Delete(DalPurchase entity)
        {
            var purchase = _context.Set<Purchase>().Single(p => p.Id == entity.Id);
            _context.Set<Purchase>().Remove(purchase);
        }

        public void Update(DalPurchase entity)
        {
            _context.Set<Purchase>().AddOrUpdate(entity.ToOrmPurchase());
        }
    }
}
