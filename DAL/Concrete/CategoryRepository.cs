using DAL.Interfaces.Interfaces;
using DAL.Interfaces.DTO;
using DAL.Interfaces;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ORM.Models;
using System.Data.Entity.Migrations;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly DbContext _context;

        public CategoryRepository(DbContext uow)
        {
            this._context = uow;
        }

        public IEnumerable<DalCategory> GetAll()
        {
            return _context.Set<Category>().ToList().Select(category => category.ToDalCategory());
        }

        public DalCategory GetById(int key)
        {
            return _context.Set<Category>().FirstOrDefault(category => category.Id == key).ToDalCategory();
        }

        public DalCategory GetByPredicate(Expression<Func<DalCategory, bool>> predicate)
        {
            var newExpression = ExpressionConverter.Convert<DalCategory, Category>(predicate);
            var category = _context.Set<Category>().FirstOrDefault(newExpression);
            return category.ToDalCategory();
        }

        public void Create(DalCategory entity)
        {
            _context.Set<Category>().Add(entity.ToOrmCategory());
        }

        public void Delete(DalCategory entity)
        {
            var category = _context.Set<Category>().Single(c => c.Id == entity.Id);
            _context.Set<Category>().Remove(category);
        }

        public void Update(DalCategory entity)
        {
            _context.Set<Category>().AddOrUpdate(entity.ToOrmCategory());
        }
    }
}
