namespace DressZone.Server.Controllers
{
    using Infrastructure.Mapping.Contracts;
    using Models.DTO.CategoriesDetails;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    public class AllCategoriesController : BaseController
    {
        private IPublicCategoriesService categoryService;

        public AllCategoriesController(IPublicCategoriesService categoriesService)
        {
            this.categoryService = categoriesService;
        }

        [HttpGet]
        [OutputCache(Duration = 300)]
        public ActionResult All()
        {
            var allCategories = this.categoryService.GetAllCategories().To<SingleCategoryDTO>().ToList();
            return View(allCategories);
        }
    }
}