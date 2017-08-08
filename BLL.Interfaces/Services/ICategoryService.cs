using System.Collections.Generic;
using BLL.Interfaces.Entities;
using System;

namespace BLL.Interfaces.Services
{
    public interface ICategoryService
    {
        CategoryEntity GetCategoryEntity(int id);
        IEnumerable<CategoryEntity> GetAllCategoryEntities();
        StatisticsEntity GetStatistics(TimeSpan? timeSpan);
        void CreateCategory(CategoryEntity category);
        void DeleteCategory(CategoryEntity category);
        void UpdateCategory(CategoryEntity category);
    }
}
