using DAL.Interfaces.DTO;
using System;
using System.Linq;
using ORM.Models;



namespace DAL.Mappers
{
    public static class DalEntityMappers
    {
        #region User

        public static DalUser ToDalUser(this User userEntity)
        {
            return userEntity==null ? null : new DalUser
            {
                Id=userEntity.Id,
                Name=userEntity.Name,
                Email=userEntity.Email,
                Password=userEntity.Password,
                CreationDate=userEntity.CreationDate,
                RoleId=userEntity.RoleId,
                Role=userEntity.Role.ToDalRole(),
                Lots=userEntity.Lots.Select(l=>l.ToDalLot()),
                Bids=userEntity.Bids.Select(b=>b.ToDalBid()),
                Comments=userEntity.Comments.Select(c=>c.ToDalComment()),
                Purchases=userEntity.Purchases.Select(p=>p.ToDalPurchase())
            };
        }

        public static User ToOrmUser(this DalUser dalUser)
        {
            User newUser = new User
            {
                Id=dalUser.Id,
                Name=dalUser.Name,
                Email=dalUser.Email,
                Password=dalUser.Password,
                CreationDate = dalUser.CreationDate,
                RoleId=dalUser.RoleId
            };
            return newUser;
        }

        #endregion

        #region Role

        public static DalRole ToDalRole(this Role roleEntity)
        {
            return roleEntity==null ? null : new DalRole
            {
                Id=roleEntity.Id,
                Name=roleEntity.Name,
                Users=roleEntity.Users.Select(u=>u.ToDalUser())
            };
        }

        public static Role ToOrmRole(this DalRole dalRole)
        {
            Role newRole=new Role
            {
                Id=dalRole.Id,
                Name=dalRole.Name
            };
            return newRole;
        }

        #endregion

        #region Category

        public static DalCategory ToDalCategory(this Category categoryEntity)
        {
            return categoryEntity== null ? null : new DalCategory
            {
                Id=categoryEntity.Id,
                Name=categoryEntity.Name,  
                ImageData=categoryEntity.ImageData,
                ImageType=categoryEntity.ImageType,
                Lots=categoryEntity.Lots.Select(l=>l.ToDalLot())
            };
        }

        public static Category ToOrmCategory(this DalCategory dalCategory)
        {
            Category newCategory = new Category
            {
                Id=dalCategory.Id,
                Name=dalCategory.Name,
                ImageData=dalCategory.ImageData,
                ImageType=dalCategory.ImageType
            };
            return newCategory;
        }

        #endregion

        #region Comment

        public static DalComment ToDalComment(this Comment commentEntity)
        {
            return commentEntity==null ? null : new DalComment
            {
                Id=commentEntity.Id,
                Text=commentEntity.Text,
                Date=commentEntity.Date,
                User=commentEntity.User.ToDalUser(),
                Lot=commentEntity.Lot.ToDalLot(),
                LotId=commentEntity.LotId,
                UserId=commentEntity.UserId
            };
        }

        public static Comment ToOrmComment(this DalComment dalComment)
        {
            Comment newComment = new Comment
            {
                Id=dalComment.Id,
                Text=dalComment.Text,
                Date=dalComment.Date,
                LotId=dalComment.LotId,
                UserId=dalComment.UserId
            };

            return newComment;
        }

        #endregion


        #region Bid

        public static DalBid ToDalBid(this Bid bidEntity)
        {
            return bidEntity==null ? null : new DalBid
            {
                Id=bidEntity.Id,
                Price=bidEntity.Price,
                Date=bidEntity.Date,
                User=bidEntity.User.ToDalUser(),  
                Lot=bidEntity.Lot.ToDalLot(),
                LotId=bidEntity.LotId,
                UserId=bidEntity.UserId
            };
        }

        public static Bid ToOrmBid(this DalBid dalBid)
        {
            Bid newBid = new Bid
            {
                Id=dalBid.Id,
                Price=dalBid.Price,
                Date=dalBid.Date,
                LotId=dalBid.LotId,
                UserId=dalBid.UserId
            };

            return newBid;
        }

        #endregion


        #region Purchase

        public static DalPurchase ToDalPurchase(this Purchase purchaseEntity)
        {
            return purchaseEntity==null ? null : new DalPurchase
            {
                Id=purchaseEntity.Id,
                Date=purchaseEntity.Date,
                User=purchaseEntity.User.ToDalUser(),
                Lot=purchaseEntity.Lot.ToDalLot(),
                LotId=purchaseEntity.LotId,
                UserId=purchaseEntity.UserId
            };
        }

        public static Purchase ToOrmPurchase(this DalPurchase dalPurchase)
        {
            return new Purchase
            {
                Id=dalPurchase.Id,
                Date = dalPurchase.Date,
                LotId=dalPurchase.LotId,
                UserId=dalPurchase.UserId
            };
        }

        #endregion


        #region Lot

        public static DalLot ToDalLot(this Lot lotEntity)
        {
            return lotEntity==null ? null : new DalLot
            {
                Id=lotEntity.Id,
                Name=lotEntity.Name,
                StartPrice=lotEntity.StartPrice,
                LastPrice=lotEntity.LastPrice,
                Description=lotEntity.Description,
                StartDate=lotEntity.StartDate,
                Duration=lotEntity.Duration,
                ImageData=lotEntity.ImageData,
                ImageType=lotEntity.ImageType,
                State=lotEntity.State.ToDalLotState(),
                User=lotEntity.User.ToDalUser(),
                Category=lotEntity.Category.ToDalCategory(),
                UserId=lotEntity.UserId,
                CategoryId=lotEntity.CategoryId,
                Bids=lotEntity.Bids.Select(b=>b.ToDalBid()),
                Comments=lotEntity.Comments.Select(c=>c.ToDalComment())
            };
        }

        public static Lot ToOrmLot(this DalLot dalLot)
        {
            Lot newLot = new Lot
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
                State=dalLot.State.ToOrmLotState(),
                UserId=dalLot.UserId,
                CategoryId=dalLot.CategoryId
            };
            return newLot;
        }

        #endregion


        #region LotState

        public static DalLotState ToDalLotState(this LotState lotStateEntity)
        {
            return (DalLotState)((int)lotStateEntity);
        }

        public static LotState ToOrmLotState(this DalLotState dalLotState)
        {
            return (LotState)((int)dalLotState);
        }

        #endregion

        #region ExceptionInformation

        public static DalExceptionInformation ToDalExceptionInformation(this ExceptionInformation exceptionInformationEntity)
        {
            return exceptionInformationEntity==null ? null : new DalExceptionInformation
            {
                Id=exceptionInformationEntity.Id,
                ExceptionMessage=exceptionInformationEntity.ExceptionMessage,
                StackTrace=exceptionInformationEntity.StackTrace,
                ActionName=exceptionInformationEntity.ActionName,
                ControllerName=exceptionInformationEntity.ControllerName,
                Date=exceptionInformationEntity.Date
            };
        }

        public static ExceptionInformation ToOrmExceptionInformation(this DalExceptionInformation dalExceptionInformation)
        {
            return new ExceptionInformation
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
