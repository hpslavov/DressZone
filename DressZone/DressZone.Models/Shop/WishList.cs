namespace DressZone.Models.Shop
{
    using Common.Contracts;
    using DressZone.Models.Shop.Common;
    using System;
    using System.Collections.Generic;
    public class WishList
    {
        private ICollection<WishListItem> products;

        public WishList()
        {
            this.products = new List<WishListItem>();
            this.CreatedOn = DateTime.Now;
        }

        public string UserId { get; set; }
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual ICollection<WishListItem> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
