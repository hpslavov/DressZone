namespace DressZone.Server.Controllers
{
    using Infrastructure.Mapping.Contracts;
    using Models.DTO.Home;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private IHomePageService indexService;

        public HomeController(IHomePageService homePageService)
        {
            this.indexService = homePageService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var resultCategories = this.indexService.GetTopCategories().To<HomeCategoryDTO>().ToList();

            var resultProducts = this.indexService.GetTopProducts().To<HomeProductDTO>().ToList();

            var resultDTO = new HomePageDTO { categories = resultCategories, products = resultProducts };

            return View(resultDTO);
        }

        
    }
}