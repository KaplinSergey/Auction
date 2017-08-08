using DAL.Interfaces.Interfaces;
using DAL.Interfaces.DTO;
using DAL.Interfaces;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ORM.Models;
using DAL.Mappers;
using System.Data.Entity.Migrations;

namespace DAL.Concrete
{
    public class BidRepository:IBidRepository
    {
        private readonly DbContext _context;

        public BidRepository(DbContext uow)
        {
            this._context = uow;
        }
        public IEnumerable<DalBid> GetAll()
        {
            return _context.Set<Bid>().ToList().Select(bid => bid.ToDalBid());
        }

        public DalBid GetById(int key)
        {
            return _context.Set<Bid>().FirstOrDefault(bid => bid.Id == key).ToDalBid();
        }

        public DalBid GetByPredicate(Expression<Func<DalBid, bool>> predicate)
        {
            var newExpression = ExpressionConverter.Convert<DalBid, Bid>(predicate);
            var bid = _context.Set<Bid>().FirstOrDefault(newExpression);
            return bid.ToDalBid();
        }

        public void Create(DalBid entity)
        {
            _context.Set<Bid>().Add(entity.ToOrmBid());
        }

        public void Delete(DalBid entity)
        {
            var bid = _context.Set<Bid>().Single(b => b.Id == entity.Id);
            _context.Set<Bid>().Remove(bid);
        }

        public void Update(DalBid entity)
        {
            _context.Set<Bid>().AddOrUpdate(entity.ToOrmBid());
        }
    }
}
