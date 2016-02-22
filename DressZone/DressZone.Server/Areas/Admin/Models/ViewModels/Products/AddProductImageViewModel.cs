namespace DressZone.Server.Areas.Admin.Models.ViewModels.Products
{
    using Infrastructure.Mapping.Contracts;
    using System.Collections.Generic;
    using System.Web;

    public class AddProductImageViewModel : IMapTo<AddProductImageRequestModel>
    {
        public int ProductId { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<HttpPostedFileBase> images { get; set; }
    }
}