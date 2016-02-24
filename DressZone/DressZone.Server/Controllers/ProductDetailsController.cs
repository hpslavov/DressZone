using DressZone.Server.Infrastructure.Mapping.Contracts;
using DressZone.Server.Models.DTO.CategoriesDetails;
using DressZone.Server.Models.DTO.ProductDetails;
using DressZone.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DressZone.Server.Controllers
{
    public class ProductDetailsController : BaseController
    {
        private IProductDetailsService productsService;

        public ProductDetailsController(IProductDetailsService service)
        {
            this.productsService = service;
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var productFromDb = this.productsService.GetCurrentProduct(id).To<SingleProductDTO>().FirstOrDefault();
            return View(productFromDb);
        }
    }
}