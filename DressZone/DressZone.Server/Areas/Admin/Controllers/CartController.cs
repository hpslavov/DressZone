using DressZone.Context.Contracts;
using DressZone.Models.Account;
using DressZone.Models.Shop;
using DressZone.Repository.Contracts;
using DressZone.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DressZone.Server.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CartController : Controller
    {
        private IAdminCartService cartService;
        private IDressZoneDbContext ctx;

        public CartController(IAdminCartService service, IDressZoneDbContext context)
        {
            this.ctx = context;
            this.cartService = service;
        }

        [HttpPost]
        public ActionResult CreateCartInitial(string UserName)
        {
            cartService.CreateInitialUserCart(UserName);
            return RedirectToAction("Index", "Home", new { area = string.Empty });
        }


    }
}