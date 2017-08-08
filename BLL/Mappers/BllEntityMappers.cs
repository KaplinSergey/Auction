using System.Linq;
using BLL.Interfaces.Entities;
using DAL.Interfaces.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        #region User

        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            return new DalUser
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email,
                Password = userEntity.Password,
                CreationDate = userEntity.CreationDate,
                RoleId = userEntity.RoleId,
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            return dalUser==null ? null : new UserEntity
            {
                Id = dalUser.Id,
                Name = dalUser.Name,
                Email = dalUser.Email,
                Password = dalUser.Password,
                CreationDate = dalUser.CreationDate,
                Role = dalUser.Role.ToBllRole(),
                RoleId = dalUser.RoleId,
                Lots = dalUser.Lots.Select(l => l.ToBllLot()),
                Bids = dalUser.Bids.Select(b => b.ToBllBid()),
                Comments = dalUser.Comments.Select(c => c.ToBllComment()),
                Purchases = dalUser.Purchases.Select(p => p.ToBllPurchase())
            };
        }

        #endregion


        #region Role

        public static DalRole ToDalRole(this RoleEntity roleEntity)
        {
            return new DalRole
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name
            };
        }

        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            return dalRole==null ? null : new RoleEntity
            {
                Id = dalRole.Id,
                Name = dalRole.Name,
                Users=dalRole.Users.Select(u=>u.ToBllUser())
            };
        }

        #endregion

        #region Category

        public static DalCategory ToDalCategory(this CategoryEntity categoryEntity)
        {
            return new DalCategory
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name,
                ImageData=categoryEntity.ImageData,
                ImageType=categoryEntity.ImageType
            };

        }

        public static CategoryEntity ToBllCategory(this DalCategory dalCategory)
        {
            return dalCategory==null ? null : new CategoryEntity
            {
                Id = dalCategory.Id,
                Name = dalCategory.Name,
                ImageData=dalCategory.ImageData,
                ImageType=dalCategory.ImageType,
                Lots=dalCategory.Lots.Select(l=>l.ToBllLot())
            };
        }

        #endregion

        #region Comment

        public static DalComment ToDalComment(this CommentEntity commentEntity)
        {
            DalComment newComment = new DalComment
            {
                Id = commentEntity.Id,
                Text = commentEntity.Text,
                Date = commentEntity.Date,
                LotId = commentEntity.LotId,
                UserId = commentEntity.UserId
            };
            return newComment;
        }

        public static CommentEntity ToBllComment(this DalComment dalComment)
        {
            return dalComment==null ? null : new CommentEntity
            {
                Id = dalComment.Id,
                Text = dalComment.Text,
                Date = dalComment.Date,
                User = dalComment.User.ToBllUser(),
                Lot = dalComment.Lot.ToBllLot(),
                LotId = dalComment.LotId,
                UserId = dalComment.UserId
            };
        }

        #endregion

        #region Bid

        public static DalBid ToDalBid(this BidEntity bidEntity)
        {
            DalBid newBid = new DalBid
            {
                Id = bidEntity.Id,
                Price = bidEntity.Price,
                Date = bidEntity.Date,
                LotId = bidEntity.LotId,
                UserId = bidEntity.UserId
            };
            return newBid;
        }

        public static BidEntity ToBllBid(this DalBid dalBid)
        {
            return dalBid==null ? null : new BidEntity
            {
                Id = dalBid.Id,
                Price = dalBid.Price,
                Date = dalBid.Date,
                User = dalBid.User.ToBllUser(),
                Lot = dalBid.Lot.ToBllLot(),
                LotId = dalBid.LotId,
                UserId = dalBid.UserId
            };
        }

        #endregion


        #region Purchase

        public static DalPurchase ToDalPurchase(this PurchaseEntity purchaseEntity)
        {
            return new DalPurchase
            {
                Id = purchaseEntity.Id,
                Date = purchaseEntity.Date,
                LotId = purchaseEntity.LotId,
                UserId = purchaseEntity.UserId
            };
        }

        public static PurchaseEntity ToBllPurchase(this DalPurchase dalPurchase)
        {
            return dalPurchase==null ? null : new PurchaseEntity
            {
                Id = dalPurchase.Id,
                Date = dalPurchase.Date,
                User = dalPurchase.User.ToBllUser(),
                Lot = dalPurchase.Lot.ToBllLot(),
                LotId = dalPurchase.LotId,
                UserId = dalPurchase.UserId
            };
        }

        #endregion

        #region Lot

        public static DalLot ToDalLot(this LotEntity lotEntity)
        {
            DalLot newLot = new DalLot
            {
                Id = lotEntity.Id,
                Name = lotEntity.Name,
                StartPrice = lotEntity.StartPrice,
                LastPrice = lotEntity.LastPrice,
                Description = lotEntity.Description,
                StartDate = lotEntity.StartDate,
                Duration = lotEntity.Duration,
                ImageData = lotEntity.ImageData,
                ImageType = lotEntity.ImageType,
                State = lotEntity.State.ToDalLotState(),
                UserId = lotEntity.UserId,
                CategoryId = lotEntity.CategoryId
            };
            return newLot;
        }

        public static LotEntity ToBllLot(this DalLot dalLot)
        {
            return dalLot==null ? null : new LotEntity
            {
                Id = dalLot.Id,
                Name = dalLot.Name,
                StartPrice = dalLot.StartPrice,
                LastPrice = dalLot.LastPrice,
                Description = dalLot.Description,
                StartDate = dalLot.StartDate,
                Duration = dalLot.Duration,
                ImageData = dalLot.ImageData,
                ImageType = dalLot.ImageType,
                State = dalLot.State.ToBllLotState(),
                User = dalLot.User.ToBllUser(),
                Category = dalLot.Category.ToBllCategory(),
                UserId = dalLot.UserId,
                CategoryId = dalLot.CategoryId,
                Bids=dalLot.Bids.Select(b=>b.ToBllBid()),
                Comments=dalLot.Comments.Select(b=>b.ToBllComment())
            };
        }

        #endregion

        #region LotState

        public static DalLotState ToDalLotState(this LotStateEntity lotStateEntity)
        {
            return (DalLotState)((int)lotStateEntity);
        }

        public static LotStateEntity ToBllLotState(this DalLotState dalLotState)
        {
            return (LotStateEntity)((int)dalLotState);
        }

        #endregion

        #region ExceptionInformation

        public static DalExceptionInformation ToDalExceptionInformation(this ExceptionInformationEntity exceptionInformationEntity)
        {
            return new DalExceptionInformation
            {
                Id = exceptionInformationEntity.Id,
                ExceptionMessage = exceptionInformationEntity.ExceptionMessage,
                StackTrace = exceptionInformationEntity.StackTrace,
                ActionName = exceptionInformationEntity.ActionName,
                ControllerName = exceptionInformationEntity.ControllerName,
                Date = exceptionInformationEntity.Date
            };
        }

        public static ExceptionInformationEntity ToBllExceptionInformation(this DalExceptionInformation dalExceptionInformation)
        {
            return dalExceptionInformation==null ? null : new ExceptionInformationEntity
            {
                Id = dalExceptionInformation.Id,
                ExceptionMessage = dalExceptionInformation.ExceptionMessage,
                StackTrace = dalExceptionInformation.StackTrace,
                ActionName = dalExceptionInformation.ActionName,
                ControllerName = dalExceptionInformation.ControllerName,
                Date = dalExceptionInformation.Date
            };
        }

        #endregion


    }
}
