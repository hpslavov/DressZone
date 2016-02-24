namespace DressZone.Server.Areas.UserArea.Controllers
{
    using Services.Contracts;
    using System.Web.Mvc;

    public class CartViewController : UserBaseController
    {
        private IUserCartService cartService;

        public CartViewController(IUserCartService srvc)
        {
            this.cartService = srvc;
        }

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

    }
}