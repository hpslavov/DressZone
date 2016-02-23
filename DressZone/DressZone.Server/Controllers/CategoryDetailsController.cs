namespace DressZone.Server.Controllers
{
    using Infrastructure.Mapping.Contracts;
    using Models.DTO.CategoriesDetails;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    public class CategoryDetailsController : BaseController
    {
        private IPublicCategoriesService categoryService;

        public CategoryDetailsController(IPublicCategoriesService categoriesService)
        {
            this.categoryService = categoriesService;
        }

        [HttpGet]
        public ActionResult Details(int categoryId = 1)
        {
            var categoryFromDb = this.categoryService
                                        .GetCurrent(categoryId)
                                        .To<SingleCategoryDTO>()
                                        .FirstOrDefault();

            var allCategories = this.categoryService
                                        .GetAllCategories()
                                        .To<SingleCategoryDTO>()
                                        .ToList();

            var result = new SideBarCategoriesDTO
            {
                allCategories = allCategories,
                currentCategory = categoryFromDb
            };

            return View(result);
        }




    }
}