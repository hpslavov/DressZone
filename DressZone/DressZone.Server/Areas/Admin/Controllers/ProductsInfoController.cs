namespace DressZone.Server.Areas.Admin.Controllers
{
    using Services.Contracts;
    using System.Web.Mvc;
    using System.Linq;

    public class ProductsInfoController : AdminBaseController
    {
        private IAdminProductsService productService;

        public ProductsInfoController(IAdminProductsService service)
        {
            this.productService = service;
        }

        [HttpGet]
        public ActionResult GetProductInfo(string productId)
        {
            if (productId != null)
            {
                var id = int.Parse(productId);
                var result = this.productService
                                            .GetAll()
                                            .Where(x => x.Id == id)
                                            .Select(j => new { j.Category.Name, j.Id })
                                            .ToArray();
                return Json(result);

            }
            return Json("");
        }
    }
}