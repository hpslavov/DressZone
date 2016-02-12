namespace DressZone.Models.Shop
{
    using DressZone.Models.Shop.Common;

    public class CategoryImage : BaseModel
    {
        public CategoryImage() : base()
        {
        }
        public string CategoryName { get; set; }
        public byte[] Image { get; set; }
    }
}
