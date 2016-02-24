namespace DressZone.Server.Controllers
{
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
    using System.Web.Mvc;

    public class UserCartController : BaseController
    {
        private IUserCartService service;

        public UserCartController(IUserCartService service)
        {
            this.service = service;
        }

        [HttpPost]
        public ActionResult AddItem(string productId)
        {
            var cartId = this.User.Identity.GetUserId();
            this.service.AddItemToCart(productId, cartId);
            return RedirectToAction("Details", "ProductDetails", new { id = productId });
        }
    }
}