using DressZone.Models.Shop;
using DressZone.Server.Infrastructure.Mapping.Contracts;
using System.Collections.Generic;

namespace DressZone.Server.Areas.Admin.Models.ViewModels
{
    public class AllCategoriesViewModel: IMapFrom<CategoryImage>
    {
        public string CategoryName { get; set; }
        public string OriginalFileName { get; set; }
       
    }
}