using DressZone.Models.Shop;
using DressZone.Repository.Contracts;
using DressZone.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressZone.Services.Admin
{
    public class AdminCategoriesService : IAdminCategoriesService
    {
        private IGenericRepository<Category> categoryRepo;
        private IImagesService categoryImages;

        public AdminCategoriesService(IGenericRepository<Category> repo,IImagesService categoryImages)
        {
            this.categoryRepo = repo;
            this.categoryImages = categoryImages;
        }

        public IQueryable<Category> GetAll()
        {
            var categories = this.categoryRepo.All().Where(c => c.IsDeleted != true);
            return categories;
        }

        public Category GetByName(string categoryName)
        {
            var category = this.categoryRepo.All().Where(c => c.Name == categoryName && c.IsDeleted != true).FirstOrDefault();
            return category;
        }

        public void CreateCategory(Category categoryToAdd)
        {
            this.categoryRepo.Add(categoryToAdd);
            this.categoryRepo.SaveChanges();
        }



    }
}
