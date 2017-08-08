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
    public class LotRepository:ILotRepository
    {
        private readonly DbContext _context;
        public LotRepository(DbContext uow)
        {
            this._context = uow;
        }

        public IEnumerable<DalLot> GetAll()
        {
            return _context.Set<Lot>().ToList().Select(lotEntity => lotEntity.ToDalLot());
        }

        public DalLot GetById(int key)
        {
            return _context.Set<Lot>().FirstOrDefault(lot => lot.Id == key).ToDalLot();
        }

        public DalLot GetByPredicate(Expression<Func<DalLot, bool>> predicate)
        {
            var newExpression = ExpressionConverter.Convert<DalLot, Lot>(predicate);
            var lot = _context.Set<Lot>().FirstOrDefault(newExpression);
            return lot.ToDalLot();
        }

        public void Create(DalLot entity)
        {
            _context.Set<Lot>().Add(entity.ToOrmLot());
        }

        public void Delete(DalLot entity)
        {
            var lot = _context.Set<Lot>().Single(l => l.Id == entity.Id);
            _context.Set<Bid>().RemoveRange(lot.Bids);
            _context.Set<Comment>().RemoveRange(lot.Comments);
            _context.Set<Lot>().Remove(lot);
        }

        public void Update(DalLot entity)
        {
            _context.Set<Lot>().AddOrUpdate(entity.ToOrmLot());
        }
    }
}
