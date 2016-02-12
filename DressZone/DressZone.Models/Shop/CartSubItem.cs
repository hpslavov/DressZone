namespace DressZone.Models.Shop
{
    using DressZone.Models.Shop.Common;
    using System.Collections.Generic;
    public class CartSubItem : BaseModel
    {
        private ICollection<Product> products;

        public CartSubItem() : base()
        {
            this.products = new List<Product>();
        }

        public int Quantity { get; set; }

        public decimal CartSubItemTotal { get; set; }
    }
}
