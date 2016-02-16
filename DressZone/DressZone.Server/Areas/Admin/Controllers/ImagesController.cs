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
    public class ImagesController : Controller
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
            //var imagesToDatabase = new List<CategoryImage>();

            //foreach (var item in imageFiles.imageFiles)
            //{
            //    if (item != null)
            //    {
            //        imagesToDatabase.Add(new CategoryImage
            //        {
            //            CategoryName = imageFiles.CategoryName,
            //            ContentLength = item.ContentLength,
            //            FileName = item.FileName,
            //            IsFrontImage = imageFiles.IsFrontImage,
            //            OriginalFileName = item.FileName,
            //            InputStream = item.InputStream,
            //            ContentType = item.ContentType,
            //        });
            //    }
            //}

            //imageService.SaveImageFile(imagesToDatabase);
            //imageService.SaveImageRecord(imagesToDatabase);
            return null;
        }
    }
}