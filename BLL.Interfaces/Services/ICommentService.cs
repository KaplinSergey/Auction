using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface ICommentService
    {
        CommentEntity GetCommentEntity(int id);
        IEnumerable<CommentEntity> GetAllCommentEntities();
        IEnumerable<CommentEntity> GetAllCommentEntitiesByLotId(int id);
        void CreateComment(CommentEntity comment);
        void DeleteComment(CommentEntity comment);
        void UpdateComment(CommentEntity comment);  
    }
}
