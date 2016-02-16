namespace DressZone.Server.Areas.Admin.Models.ViewModels
{
    using DressZone.Models.Shop;
    using DressZone.Server.Infrastructure.Mapping.Contracts;
    using System.IO;
    using System.Web;

    public class AddCategoryRequestModel : IMapFrom<HttpPostedFileBase>,IMapTo<CategoryImage>
    {
        public string CategoryName { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public bool IsFrontImage { get; set; }

        public string OriginalFileName { get; set; }

        public Stream InputStream { get; set; }

        public int ContentLength { get; set; }
    }
}