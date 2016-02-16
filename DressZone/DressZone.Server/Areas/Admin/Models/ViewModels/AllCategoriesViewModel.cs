using DressZone.Models.Shop;
using DressZone.Server.Infrastructure.Mapping.Contracts;
using System.Collections.Generic;

namespace DressZone.Server.Areas.Admin.Models.ViewModels
{
    public class AllCategoriesViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }
        public string FrontImageName { get; set; }
        public string Description { get; set; }
    }
}