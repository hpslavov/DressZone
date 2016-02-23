namespace DressZone.Server.Areas.Admin.Models.ViewModels
{
    using DressZone.Models.Shop;
    using Infrastructure.Mapping.Contracts;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;

    public class AddImageResponseModel :  IMapTo<CategoryImage>
    {
        public IEnumerable<HttpPostedFileBase> imageFiles { get; set; }
        public int ContentLength { get; set; }
        public string CategoryName { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public Stream InputStream { get; set; }
    }
}
