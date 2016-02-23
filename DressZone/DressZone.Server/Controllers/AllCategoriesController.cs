namespace DressZone.Server.Controllers
{
    using System.Web.Mvc;

    public class AllCategoriesController : BaseController
    {
        [HttpGet]
        [OutputCache(Duration = 300)]
        public ActionResult All()
        {
            return View();
        }
    }
}