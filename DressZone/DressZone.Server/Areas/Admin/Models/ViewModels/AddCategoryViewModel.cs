using DressZone.Models.Shop;
using DressZone.Server.Infrastructure.Mapping.Contracts;
using System.Collections.Generic;
using System.Web;

namespace DressZone.Server.Areas.Admin.Models.ViewModels
{
    public class AddCategoryViewModel : IMapTo<AddCategoryRequestModel>
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public IEnumerable<HttpPostedFileBase> Images { get; set; }
    }
}