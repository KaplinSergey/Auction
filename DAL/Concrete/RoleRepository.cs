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
    public class RoleRepository:IRoleRepository
    {
        private readonly DbContext _context;

        public RoleRepository(DbContext uow)
        {
            this._context = uow;
        }
        public IEnumerable<DalRole> GetAll()
        {
            return _context.Set<Role>().ToList().Select(role => role.ToDalRole());
        }

        public DalRole GetById(int key)
        {
            return _context.Set<Role>().FirstOrDefault(role => role.Id == key).ToDalRole();
        }

        public DalRole GetRoleByName(string name)
        {
            return _context.Set<Role>().FirstOrDefault(role => role.Name.Contains(name)).ToDalRole();
        }

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> predicate)
        {
            var newExpression = ExpressionConverter.Convert<DalRole, Role>(predicate);
            var role = _context.Set<Role>().FirstOrDefault(newExpression);
            return role.ToDalRole();
        }

        public void Create(DalRole entity)
        {
            _context.Set<Role>().Add(entity.ToOrmRole());
        }

        public void Delete(DalRole entity)
        {
            var role = _context.Set<Role>().Single(r => r.Id == entity.Id);
            _context.Set<Role>().Remove(role);
        }

        public void Update(DalRole entity)
        {
            _context.Set<Role>().AddOrUpdate(entity.ToOrmRole());
        }
    }
}
