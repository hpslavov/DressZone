namespace DressZone.Services.Shop
{
    using System;
    using System.Linq;
    using Models.Shop;
    using DressZone.Services.Contracts;
    using Repository.Contracts;
    public class ProductDetailsService : IProductDetailsService
    {
        private IGenericRepository<Product> products;

        public ProductDetailsService(IGenericRepository<Product> productsRepo)
        {
            this.products = productsRepo;
        }

        public IQueryable<Product> GetCurrentProduct(int id)
        {
            var current = this.products.All().Where(p => p.Id == id);
            return current;
        }
    }
}
