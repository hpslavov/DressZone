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

        public IQueryable<Category> GetAllWithDeleted()
        {
            var categories = this.categoryRepo.All();
            return categories;
        }

        public Category GetByName(string categoryName)
        {
            var category = this.categoryRepo.All().Where(c => c.Name == categoryName && c.IsDeleted != true).FirstOrDefault();
            return category;
        }

        public void CreateCategory(Category categoryToAdd,List<CategoryImage> images)
        {
            categoryToAdd.Images = images;
            this.categoryRepo.Add(categoryToAdd);
            this.categoryRepo.SaveChanges();
        }

        public Category EditCategory(Category categoryToUpdate)
        {
            categoryToUpdate.ModifiedOn = DateTime.Now;
            this.categoryRepo.Update(categoryToUpdate);
            this.categoryRepo.SaveChanges();
            return categoryToUpdate;
        }

        public Category Delete(Category categoryToDelete)
        {
            categoryToDelete.DeletedOn = DateTime.Now;
            categoryToDelete.IsDeleted = true;
            this.categoryRepo.AddDeleteFlag(categoryToDelete);
            this.categoryRepo.SaveChanges();
            return categoryToDelete;
        }


    }
}
