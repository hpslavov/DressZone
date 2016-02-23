namespace DressZone.Server.Areas.Admin.Models.ViewModels.Products
{
    using DressZone.Models.Shop;
    using Infrastructure.Mapping.Contracts;
    using System.IO;
    using System.Web;

    public class AddProductImageRequestModel : IMapFrom<HttpPostedFileBase>,IMapTo<ProductImage>
    {
        public string FileName { get; set; }

        public string ContentType { get; set; }

        public bool IsFrontImage { get; set; }

        public string OriginalFileName { get; set; }

        public Stream InputStream { get; set; }

        public int ContentLength { get; set; }
    }
}