namespace DressZone.Server.Controllers
{
    using Infrastructure.Mapping.Contracts;
    using Models.DTO.Home;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : BaseController
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


            var resultProducts = this.indexService.GetTopProducts().Select(p => new HomeProductDTO
            {
                Id = p.Id,
                CategoryName = p.Category.Name,
                FileName = p.Images.AsQueryable().Where(i => i.ProductId == p.Id).FirstOrDefault().FileName,
                Price = p.Price,
                Title = p.Title,
                Discount = p.Discount
            });
            //this.indexService.GetTopProducts().To<HomeProductDTO>().ToList();

            var resultDTO = new HomePageDTO { categories = resultCategories, products = resultProducts };

            return View(resultDTO);
        }


    }
}