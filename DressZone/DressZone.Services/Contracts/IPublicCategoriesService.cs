namespace DressZone.Services.Contracts
{
    using Models.Shop;
    using System.Linq;

    public interface IPublicCategoriesService
    {
        IQueryable<Category> GetAllCategories();
        IQueryable<Category> GetCurrent(int categoryId);
    }
}
