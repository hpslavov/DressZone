namespace DressZone.Server.Models.DTO.Home
{
    using DressZone.Models.Shop;
    using DressZone.Server.Infrastructure.Mapping.Contracts;

    public class HomeCategoryDTO : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FrontImageName { get; set; }
    }
}