namespace DressZone.Services.Shop
{
    using DressZone.Services.Contracts;
    using Models.Shop;
    using Repository.Contracts;
    using System;
    using System.Linq;

    public class HomePageService : IHomePageService
    {
        private IGenericRepository<Category> categories;
        private IGenericRepository<Product> products;


        public HomePageService(IGenericRepository<Category> categories, IGenericRepository<Product> products)
        {
            this.categories = categories;
            this.products = products;
        }


        public IQueryable<Category> GetTopCategories()
        {
            var categories = this.categories.All().OrderBy(x => Guid.NewGuid()).Take(3);
            return categories;
        }

        public IQueryable<Product> GetTopProducts()
        {
            var products = this.products.All().OrderBy(x => Guid.NewGuid()).Take(4);
            return products;
        }

    }
}
