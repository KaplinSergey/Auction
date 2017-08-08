using BLL.Interfaces.Entities;
using MvcPL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPLMappers
    {
        public static UserViewModel ToMvcUser(this UserEntity userEntity)
        {
            return new UserViewModel()
            {
                Id = userEntity.Id,
                Email = userEntity.Email,
                Password = userEntity.Password,
                Name = userEntity.Name,
                CreationDate = userEntity.CreationDate,
                RoleId = userEntity.RoleId
            };
        }

        public static UserInfoViewModel ToMvcUserInfo(this UserEntity userEntity)
        {
            return new UserInfoViewModel()
            {
                Id = userEntity.Id,
                Email = userEntity.Email,
                Name = userEntity.Name,
                NumberOfForSaleLots=userEntity.Lots.Count(u=>u.State==LotStateEntity.ForSale),
                NumberOfUnsoldLots = userEntity.Lots.Count(u => u.State == LotStateEntity.Unsold),
                NumberOfSoldLots = userEntity.Lots.Count(u => u.State == LotStateEntity.Sold),
                NumberOfBids=userEntity.Bids.Count(),
                NumberOfPurchases=userEntity.Purchases.Count()
            };
        }

        public static UserEntity ToBllUser(this UserViewModel userViewModel)
        {
            return new UserEntity()
            {
                Id = userViewModel.Id,
                Email = userViewModel.Email,
                Password = userViewModel.Password,
                CreationDate = userViewModel.CreationDate,
                RoleId = userViewModel.RoleId
            };
        }

        public static LotViewModel ToMvcLot(this LotEntity lotEntity)
        {
            return new LotViewModel()
            {
                Id = lotEntity.Id,
                Name=lotEntity.Name,
                StartPrice=lotEntity.StartPrice,
                Description=lotEntity.Description,
                StartDate=lotEntity.StartDate,
                Duration=lotEntity.Duration,
                LastPrice=lotEntity.LastPrice,
                ImageData=lotEntity.ImageData,
                ImageType=lotEntity.ImageType,
                State = lotEntity.State.ToMvcLotState(),
                CategoryId=lotEntity.CategoryId,
                UserId=lotEntity.UserId,
                OwnerName=lotEntity.User.Name
            };
        }

        public static LotEntity ToBllLot(this LotViewModel lotViewModel)
        {
            return new LotEntity()
            {
                Id = lotViewModel.Id,
                Name = lotViewModel.Name,
                StartPrice = lotViewModel.StartPrice,
                Description = lotViewModel.Description,
                StartDate = lotViewModel.StartDate,
                Duration = lotViewModel.Duration,
                LastPrice = lotViewModel.LastPrice,
                ImageData = lotViewModel.ImageData,
                ImageType = lotViewModel.ImageType,
                State = lotViewModel.State.ToBllLotState(),
                CategoryId = lotViewModel.CategoryId,
                UserId = lotViewModel.UserId
            };
        }

        public static LotStateViewModel ToMvcLotState(this LotStateEntity lotStateEntity)
        {
            return (LotStateViewModel)(int)lotStateEntity;
        }

        public static LotStateEntity ToBllLotState(this LotStateViewModel lotStateViewModel)
        {
            return (LotStateEntity)(int)lotStateViewModel;
        }

        public static BidViewModel ToMvcBid(this BidEntity bidEntity)
        {
            return new BidViewModel()
            {
                Id = bidEntity.Id,
                Price=bidEntity.Price,
                Date=bidEntity.Date,
                LotId=bidEntity.LotId,
                UserId=bidEntity.UserId,
                LotName=bidEntity.Lot.Name,
                UserName=bidEntity.User.Name
            };
        }

        public static BidEntity ToBllBid(this BidViewModel bidViewModel)
        {
            return new BidEntity()
            {
                Id = bidViewModel.Id,
                Price = bidViewModel.Price,
                Date = bidViewModel.Date,
                LotId = bidViewModel.LotId,
                UserId = bidViewModel.UserId
            };
        }

        public static CategoryViewModel ToMvcCategory(this CategoryEntity categoryEntity)
        {
            return new CategoryViewModel()
            {
                Id = categoryEntity.Id,
                Name=categoryEntity.Name,
                ImageData=categoryEntity.ImageData,
                ImageType=categoryEntity.ImageType
            };
        }

        public static CategoryEntity ToBllCategory(this CategoryViewModel categoryViewModel)
        {
            return new CategoryEntity()
            {
                Id = categoryViewModel.Id,
                Name = categoryViewModel.Name,
                ImageData=categoryViewModel.ImageData,
                ImageType=categoryViewModel.ImageType
            };
        }

        public static CommentViewModel ToMvcComment(this CommentEntity commentEntity)
        {
            return new CommentViewModel()
            {
                Id = commentEntity.Id,
                Text=commentEntity.Text,
                Date=commentEntity.Date,
                LotId=commentEntity.LotId,
                UserId=commentEntity.UserId,
                UserName = commentEntity.User.Name
            };
        }

        public static CommentEntity ToBllComment(this CommentViewModel commentViewModel)
        {
            return new CommentEntity()
            {
                Id = commentViewModel.Id,
                Text = commentViewModel.Text,
                Date = commentViewModel.Date,
                LotId = commentViewModel.LotId,
                UserId = commentViewModel.UserId
            };
        }

        public static StatisticsViewModel ToMvcStatistics(this StatisticsEntity statistics)
        {
            return new StatisticsViewModel()
            {
                Categories=statistics.Categories,
                TotalNumberOfLots=statistics.TotalNumberOfLots,
                NumberOfSoldLots=statistics.NumberOfSoldLots,
                NumberOfForSaleLots=statistics.NumberOfForSaleLots,
                NumberOfUnsoldLots=statistics.NumberOfUnsoldLots
            };
        }

        public static PurchaseViewModel ToMvcPurchase(this PurchaseEntity purchaseEntity)
        {
            return new PurchaseViewModel()
            {
                Id = purchaseEntity.Id,
                Date=purchaseEntity.Date,
                StartPrice=purchaseEntity.Lot.StartPrice,
                LotName=purchaseEntity.Lot.Name,
                Description=purchaseEntity.Lot.Description,
                LotId=purchaseEntity.LotId,
                UserId=purchaseEntity.UserId,
                PurchasePrice = (decimal)purchaseEntity.Lot.LastPrice,
            };
        }

    }
}