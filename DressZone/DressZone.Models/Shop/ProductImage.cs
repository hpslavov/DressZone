namespace DressZone.Models.Shop
{
    using DressZone.Models.Shop.Common;

    public class ProductImage : BaseModel
    {
        ProductImage() : base()
        {

        }
        public string ProductName { get; set; }
        public byte[] Image { get; set; }
    }
}
