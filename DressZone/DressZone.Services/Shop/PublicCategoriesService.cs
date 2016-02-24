namespace DressZone.Services.Shop
{
    using System;
    using System.Linq;
    using Models.Shop;
    using DressZone.Services.Contracts;
    using Repository.Contracts;

    public class PublicCategoriesService : IPublicCategoriesService
    {
        private IGenericRepository<Category> categoriesRepo;

        public PublicCategoriesService(IGenericRepository<Category> categoryRepo)
        {
            this.categoriesRepo = categoryRepo;
        }
        public IQueryable<Category> GetAllCategories()
        {
            var allCategories = this.categoriesRepo.All().Where(c => c.IsDeleted != true);
            return allCategories;
        }

        public IQueryable<Category> GetCurrent(int categoryId)
        {
            var currentCategory = this.categoriesRepo.All().Where(x => x.Id == categoryId && x.IsDeleted != true);
            return currentCategory;
        }
    }
}
