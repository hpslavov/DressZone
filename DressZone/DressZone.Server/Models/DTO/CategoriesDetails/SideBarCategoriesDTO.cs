namespace DressZone.Server.Models.DTO.CategoriesDetails
{
    using ProductDetails;
    using System.Collections.Generic;

    public class SideBarCategoriesDTO
    {
        public IEnumerable<SingleCategoryDTO> allCategories { get; set; }
        public SingleCategoryDTO currentCategory { get; set; }
    }
}