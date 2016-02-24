using DressZone.Context.Contracts;
using DressZone.Models.Account;
using DressZone.Models.Shop;
using DressZone.Repository.Contracts;
using DressZone.Server.Areas.Admin.Models.ViewModels.Carts;
using DressZone.Server.Infrastructure.Mapping.Contracts;
using DressZone.Services.Contracts;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DressZone.Server.Areas.Admin.Controllers
{
    public class CartController : AdminBaseController
    {
        private IAdminCartService cartService;
        private IAdminUserService userService;

        public CartController(IAdminCartService service, IAdminUserService userService)
        {
            this.cartService = service;
            this.userService = userService;
        }

        public ActionResult CreateCartInitial(string UserName)
        {
            cartService.CreateInitialUserCart(UserName);
            return RedirectToAction("Index", "Home", new { area = string.Empty });
        }

        [HttpGet]
        public ActionResult All()
        {
            return View();
        }

        [HttpPost]
        public ActionResult All([DataSourceRequest]DataSourceRequest model)
        {
            var result = this.cartService.AllCarts().To<AllCartsGridViewModel>().ToList();

            return Json(result.ToDataSourceResult(model));
        }

        [HttpPost]
        public ActionResult UpdateExisting([DataSourceRequest]DataSourceRequest request, AllCartsGridViewModel cartModel)
        {
            if (!this.ModelState.IsValid)
            {
                return Json(new[] { cartModel }.ToDataSourceResult(request, ModelState));
            }

            var cartToUpdate = this.Mapper.Map<Cart>(cartModel);

            var result = this.cartService.UpdateCart(cartToUpdate);

            return Json(new[] { result }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Delete([DataSourceRequest]DataSourceRequest request, AllCartsGridViewModel cartModel)
        {
            var cartToDelete = this.Mapper.Map<Cart>(cartModel);
            this.cartService.DeleteCart(cartToDelete);
            return Json(new[] { cartModel }.ToDataSourceResult(request, ModelState));
        }
    }
}