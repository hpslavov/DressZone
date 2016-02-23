namespace DressZone.Services.Contracts
{
    using DressZone.Models.Shop;
    using System.Linq;

    public interface IHomePageService
    {
        IQueryable<Category> GetTopCategories();
        IQueryable<Product> GetTopProducts();
    }
}
