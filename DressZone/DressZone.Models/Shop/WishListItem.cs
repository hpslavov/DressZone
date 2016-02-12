namespace DressZone.Models.Shop
{
    using DressZone.Models.Shop.Common;

    public class WishListItem : BaseModel
    {
        public WishListItem():base()
        {

        }

        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public bool StockStatus { get; set; }
    }
}
