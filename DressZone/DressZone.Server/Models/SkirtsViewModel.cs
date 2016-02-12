namespace DressZone.Server.Models
{
    using DressZone.Models.Shop;
    using DressZone.Server.Infrastructure.Mapping.Contracts;

    public class SkirtsViewModel : IMapFrom<Category>,IMapTo<Category>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}