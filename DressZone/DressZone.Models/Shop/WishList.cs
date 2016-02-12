namespace DressZone.Models.Shop
{
    using DressZone.Models.Shop.Common;
    using System.Collections.Generic;
    public class WishList : BaseModel
    {
        private ICollection<WishListItem> products;

        public WishList() : base()
        {
            this.products = new List<WishListItem>();
        }

        public string UserId { get; set; }

        public virtual ICollection<WishListItem> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
