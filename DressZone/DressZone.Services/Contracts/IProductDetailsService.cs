namespace DressZone.Services.Contracts
{
    using Models.Shop;
    using System.Linq;

    public interface IProductDetailsService
    {
        IQueryable<Product> GetCurrentProduct(int id);
      
    }
}
