using DressZone.Models.Shop;
using DressZone.Server.Areas.Admin.Models.ViewModels.Products;
using DressZone.Server.Infrastructure.Mapping.Contracts;
using DressZone.Services.Contracts;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DressZone.Models.Account;
using DressZone.Services.DTO;

namespace DressZone.Server.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsCreateController : AdminBaseController
    {
        private IAdminProductsService products;

        public ProductsCreateController(IAdminProductsService productsService)
        {
            this.products = productsService;
        }

        [HttpGet]
        public ActionResult All()
        {
            ViewData["Colors"] = this.products.GetColorNames();
            ViewData["Category"] = this.products.GetCategoryNames();
            ViewData["Sizes"] = this.products.GetSizesNames();
            ViewData["Genders"] = this.products.GetGenderNames();

            return View();
        }

        [HttpPost]
        public ActionResult All([DataSourceRequest]DataSourceRequest productsModel)
        {
            var allProducts = this.products
                                    .GetAllWithDeleted()
                                    .To<GridCreateProductViewModel>()
                                    .ToList();
            
            return Json(allProducts.ToDataSourceResult(productsModel));
        }


        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models[0]")]GridCreateProductViewModel modelToCreate)
        {
            var productToCreate = new Product
            {
                Title = modelToCreate.Title,
                Description = modelToCreate.Description,
                Price = modelToCreate.Price,
                Quantity = modelToCreate.Quantity
            };
            var productFromDb = products.CreateProduct(productToCreate,
                                                       modelToCreate.Color.Id,
                                                       modelToCreate.Category.Id,
                                                       modelToCreate.Size.Id,
                                                       modelToCreate.Gender.Id);

            var result = new[] { productFromDb }.ToDataSourceResult(request, ModelState);
            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateExisting([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models[0]")]GridCreateProductViewModel modelToCreate)
        {
            var productToAdd = new List<string>();

            return Json(modelToCreate);
        }
    }
}