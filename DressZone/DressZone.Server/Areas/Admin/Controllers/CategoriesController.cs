using DressZone.Models.Shop;
using DressZone.Server.Areas.Admin.Models.ViewModels;
using DressZone.Server.Infrastructure.Mapping.Contracts;
using DressZone.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DressZone.Server.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private IAdminCategoriesService categories;
        private IImagesService images;

        public CategoriesController(IAdminCategoriesService categories, IImagesService categoryImages)
        {
            this.categories = categories;
            this.images = categoryImages;
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(AddCategoryViewModel model)
        {

            var buffer = new List<AddCategoryRequestModel>();
            var imagesToDatabase = new List<CategoryImage>();
            var categoryToDatabase = new List<Category>();

            buffer = model.Images.Where(x => x.ContentLength > 0).AsQueryable().To<AddCategoryRequestModel>().ToList();

            foreach (var item in model.Images)
            {
                var current = new CategoryImage
                {
                    CategoryName = model.CategoryName,
                    FileName = item.FileName,
                    IsFrontImage = true,
                    OriginalFileName = item.FileName,
                    InputStream = item.InputStream,
                    ContentLength = item.ContentLength,
                    ContentType = item.ContentType
                };
                imagesToDatabase.Add(current);
            }

            var categoryToAdd = new Category
            {
                Name = model.CategoryName,
                Description = model.CategoryDescription,
                FrontImageName = imagesToDatabase[0].FileName,
                Quantity = 0
            };
            categories.CreateCategory(categoryToAdd);
            images.SaveImageFile(imagesToDatabase);
            images.SaveImageRecord(imagesToDatabase);

            return RedirectToAction("All","Categories");
        }

        public ActionResult All()
        {
            var allCategoryImages = images.GetAllFrontCategoryImages().To<AllCategoriesViewModel>().ToList();
            return View("All", allCategoryImages);
        }

        [HttpGet]
        public ActionResult EditFrontImage(string category)
        {
            var categoryFromDb = this.categories.GetByName(category);
            var frontIMage = this.images.GetFrontCategoryImage(categoryFromDb.Name).FirstOrDefault();
            var categoryResponse = new EditCategoryImageRequestModel
            {
                CategoryDescription = categoryFromDb.Description,
                CategoryName = categoryFromDb.Name,
                OriginalImageName = frontIMage.OriginalFileName,
                Quantity = categoryFromDb.Quantity
            };
            return View(categoryResponse);
        }


    }
}