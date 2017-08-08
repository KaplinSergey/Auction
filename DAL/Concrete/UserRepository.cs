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
using ORM;


namespace DAL.Concrete
{
    public class UserRepository:IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext uow)
        {
            this._context = uow;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return _context.Set<User>().ToList().Select(userEntity => userEntity.ToDalUser());
        }

        public DalUser GetById(int key)
        {
            return _context.Set<User>().FirstOrDefault(user => user.Id == key).ToDalUser();

        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> predicate)
        {
            var newExpression = ExpressionConverter.Convert<DalUser, User>(predicate);
            var user = _context.Set<User>().FirstOrDefault(newExpression);
            return user.ToDalUser();
        }

        public DalUser GetByEmail(string email)
        {
            return _context.Set<User>().FirstOrDefault(user => user.Email.Contains(email)).ToDalUser();
        }
        public void Create(DalUser entity)
        {
            _context.Set<User>().Add(entity.ToOrmUser());
        }

        public void Delete(DalUser entity)
        {
            var user = _context.Set<User>().Single(u => u.Id == entity.Id);
            _context.Set<Bid>().RemoveRange(user.Bids);
            _context.Set<Comment>().RemoveRange(user.Comments);
            _context.Set<Lot>().RemoveRange(user.Lots);
            _context.Set<Purchase>().RemoveRange(user.Purchases);
            _context.Set<User>().Remove(user);
        }

        public void Update(DalUser entity)
        {
            _context.Set<User>().AddOrUpdate(entity.ToOrmUser());
        }
    }
}
