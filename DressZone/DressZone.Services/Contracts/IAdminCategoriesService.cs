using DressZone.Models.Shop;
using System.Collections.Generic;
using System.Linq;

namespace DressZone.Services.Contracts
{
    public interface IAdminCategoriesService
    {
        IQueryable<Category> GetAll();
        Category GetByName(string categoryName);
        void CreateCategory(Category categoryToAdd, List<CategoryImage> images);
        void EditCategory(Category categoryToUpdate);
    }
}
