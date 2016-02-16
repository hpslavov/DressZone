namespace DressZone.Server.Areas.Admin.Controllers
{
    using Services.Contracts;
    using System.Web.Mvc;

    [Authorize]
    public class HomeController : Controller
    {
        private IAdminHomeService homeService;

        public HomeController(IAdminHomeService service)
        {
            this.homeService = service;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}