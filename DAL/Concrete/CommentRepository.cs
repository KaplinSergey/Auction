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
    public class CommentRepository:ICommentRepository
    {
        private readonly DbContext _context;

        public CommentRepository(DbContext uow)
        {
            this._context = uow;
        }
        public IEnumerable<DalComment> GetAll()
        {
            return _context.Set<Comment>().ToList().Select(comment => comment.ToDalComment());
        }

        public DalComment GetById(int key)
        {
            return _context.Set<Comment>().FirstOrDefault(comment => comment.Id == key).ToDalComment();
        }

        public DalComment GetByPredicate(Expression<Func<DalComment, bool>> predicate)
        {
            var newExpression = ExpressionConverter.Convert<DalComment, Comment>(predicate);
            var comment = _context.Set<Comment>().FirstOrDefault(newExpression);
            return comment.ToDalComment();
        }

        public void Create(DalComment entity)
        {
            _context.Set<Comment>().Add(entity.ToOrmComment());
        }

        public void Delete(DalComment entity)
        {
            var comment = _context.Set<Comment>().Single(c => c.Id == entity.Id);
            _context.Set<Comment>().Remove(comment);
        }

        public void Update(DalComment entity)
        {
            var comment = _context.Set<Comment>().Single(c => c.Id == entity.Id);
            comment.Text = entity.Text;
            _context.Set<Comment>().AddOrUpdate(comment);
        }
    }
}
