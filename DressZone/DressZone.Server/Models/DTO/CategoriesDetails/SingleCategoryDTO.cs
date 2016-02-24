namespace DressZone.Server.Models.DTO.CategoriesDetails
{
    using DressZone.Models.Shop;
    using DressZone.Server.Infrastructure.Mapping.Contracts;
    using System.Collections.Generic;

    public class SingleCategoryDTO : IMapFrom<Category>
    {
        private ICollection<CategoryImage> images;

        public SingleCategoryDTO()
        {
            this.images = new List<CategoryImage>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string FrontImageName { get; set; }

        public ICollection<CategoryImage> Images { get; set; }
    }
}