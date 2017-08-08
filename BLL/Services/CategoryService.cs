using System;
using System.Collections.Generic;
using BLL.Interfaces.Services;
using BLL.Interfaces.Entities;
using BLL.Mappers;
using DAL.Interfaces.Interfaces;
using System.Linq;

namespace BLL.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IUnitOfWork uow;
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(IUnitOfWork uow, ICategoryRepository repository)
        {
            this.uow = uow;
            this.categoryRepository = repository;
        }

        public CategoryEntity GetCategoryEntity(int id)
        {
            return categoryRepository.GetById(id).ToBllCategory();
        }

        public IEnumerable<CategoryEntity> GetAllCategoryEntities()
        {
            return categoryRepository.GetAll().Select(category => category.ToBllCategory());
        }


        public void CreateCategory(CategoryEntity category)
        {
            categoryRepository.Create(category.ToDalCategory());
            uow.Commit();
        }

        public void DeleteCategory(CategoryEntity category)
        {
            categoryRepository.Delete(category.ToDalCategory());
            uow.Commit();
        }

        public void UpdateCategory(CategoryEntity category)
        {
            categoryRepository.Update(category.ToDalCategory());
            uow.Commit();
        }

        public StatisticsEntity GetStatistics(TimeSpan? timeSpan)
        {
            StatisticsEntity statistics = new StatisticsEntity();
            IEnumerable<CategoryEntity> categories = categoryRepository.GetAll().Select(c=>c.ToBllCategory());
            if (timeSpan==null)
            {
                foreach (var item in categories)
                {
                    statistics.Categories.Add(item.Name);
                    statistics.TotalNumberOfLots.Add(item.Lots.Count());
                    statistics.NumberOfSoldLots.Add(item.Lots.Count(l => l.State == LotStateEntity.Sold));
                    statistics.NumberOfForSaleLots.Add(item.Lots.Count(l => l.State == LotStateEntity.ForSale));
                    statistics.NumberOfUnsoldLots.Add(item.Lots.Count(l => l.State == LotStateEntity.Unsold));
                }
            }
            else
            {          
                foreach (var item in categories)
                {
                    statistics.Categories.Add(item.Name);
                    statistics.TotalNumberOfLots.Add(item.Lots.Count(l => l.StartDate > DateTime.Now - timeSpan));
                    statistics.NumberOfSoldLots.Add(item.Lots.Count(l => l.StartDate > DateTime.Now - timeSpan && l.State == LotStateEntity.Sold));
                    statistics.NumberOfForSaleLots.Add(item.Lots.Count(l => l.StartDate > DateTime.Now - timeSpan && l.State==LotStateEntity.ForSale));
                    statistics.NumberOfUnsoldLots.Add(item.Lots.Count(l => l.StartDate > DateTime.Now - timeSpan && l.State == LotStateEntity.Unsold));                    
                }
            }
            return statistics;
        }
    }
}
