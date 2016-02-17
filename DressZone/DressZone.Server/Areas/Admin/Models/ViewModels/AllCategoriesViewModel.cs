using DressZone.Models.Shop;
using DressZone.Server.Infrastructure.Mapping.Contracts;
using System;
using System.Collections.Generic;

namespace DressZone.Server.Areas.Admin.Models.ViewModels
{
    public class AllCategoriesViewModel : IMapFrom<Category>,IMapTo<Category>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FrontImageName { get; set; }
        public string Description { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}