namespace DressZone.Server.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using DressZone.Server.Areas.Admin.Models.ViewModels;
    using Infrastructure.Mapping;
    using Services.Contracts;
    using DressZone.Models.Shop;
    using Infrastructure.Mapping.Contracts;

    [Authorize]
    public class ImagesController : AdminBaseController
    {
        private IImagesService imageService;

        public ImagesController(IImagesService service)
        {
            this.imageService = service;
        }

        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveImage(AddImageResponseModel imageFiles)
        {
          
            return null;
        }
    }
}