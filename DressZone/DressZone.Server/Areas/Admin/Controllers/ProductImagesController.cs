namespace DressZone.Server.Areas.Admin.Controllers
{
    using DressZone.Models.Shop;
    using Infrastructure.Mapping.Contracts;
    using Models.ViewModels.Products;
    using Services.Contracts;
    using Services.DTO;
    using System.Linq;
    using System.Web.Mvc;

    public class ProductImagesController : AdminBaseController
    {
        private IAdminProductsService products;
        private IAdminProductImagesService images;

        public ProductImagesController(IAdminProductsService productsService, IAdminProductImagesService imagesService)
        {
            this.products = productsService;
            this.images = imagesService;
        }

        [HttpGet]
        public ActionResult AddImages(ProductInfoDTO model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult AddImages(AddProductImageViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(new { model.ProductId, model.CategoryName });//TODO REFACTOR!
            }
            var product = this.products.GetById(model.ProductId);
            var productImages = model.images
                                        .AsQueryable()
                                        .To<AddProductImageRequestModel>()
                                        .To<ProductImage>()
                                        .ToList();

            foreach (var pr in productImages)
            {
                pr.ProductId = model.ProductId;
                pr.CategoryName = model.CategoryName;
            }

            this.images.SaveImageFile(productImages);
            this.images.SaveImageRecord(productImages);

            var latestImages = this.images.GetLatest();
            this.products.SaveImagesToProduct(productImages, product);
            
            return RedirectToAction("Index","Home",new { area = string.Empty });
        }
    }
}