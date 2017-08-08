using System;
using System.Collections.Generic;
using BLL.Interfaces.Services;
using BLL.Interfaces.Entities;
using BLL.Mappers;
using DAL.Interfaces.Interfaces;
using System.Linq;

namespace BLL.Services
{
    public class CommentService:ICommentService
    {
        private readonly IUnitOfWork uow;
        private readonly ICommentRepository commentRepository;
        public CommentService(IUnitOfWork uow, ICommentRepository repository)
        {
            this.uow = uow;
            this.commentRepository = repository;
        }

        public CommentEntity GetCommentEntity(int id)
        {
            return commentRepository.GetById(id).ToBllComment();
        }

        public IEnumerable<CommentEntity> GetAllCommentEntities()
        {
            return commentRepository.GetAll().Select(comment => comment.ToBllComment());
        }

        public IEnumerable<CommentEntity> GetAllCommentEntitiesByLotId(int id)
        {
            return GetAllCommentEntities().Where(c => c.LotId == id);
        }

        public void CreateComment(CommentEntity comment)
        {
            commentRepository.Create(comment.ToDalComment());
            uow.Commit();
        }

        public void DeleteComment(CommentEntity comment)
        {
            commentRepository.Delete(comment.ToDalComment());
            uow.Commit();
        }

        public void UpdateComment(CommentEntity comment)
        {
            commentRepository.Update(comment.ToDalComment());
            uow.Commit();
        }
    }
}
