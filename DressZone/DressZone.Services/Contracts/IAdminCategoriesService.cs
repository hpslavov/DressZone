using DressZone.Models.Shop;
using System.Collections.Generic;
using System.Linq;

namespace DressZone.Services.Contracts
{
    public interface IAdminCategoriesService
    {
        IQueryable<Category> GetAll();
        IQueryable<Category> GetAllWithDeleted();
        Category GetByName(string categoryName);
        void CreateCategory(Category categoryToAdd, List<CategoryImage> images);
        Category EditCategory(Category categoryToUpdate);
        Category Delete(Category categoryToDelete);
    }
}
