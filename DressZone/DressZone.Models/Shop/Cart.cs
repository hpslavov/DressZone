namespace DressZone.Models.Shop
{
    using Account;
    using DressZone.Models.Shop.Common;
    using System;
    using System.Collections.Generic;
    public class Cart : BaseModel
    {
        private ICollection<CartSubItem> subItems;

        public Cart():base()
        {
            this.subItems = new List<CartSubItem>();
        }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public bool IsCheckedOut { get; set; }

        public decimal SubTotal { get; set; }

        public int? ShippingId { get; set; }

        public virtual Shipping Shipping { get; set; }

        public decimal Total { get; set; }

        public virtual ICollection<CartSubItem> SubItems
        {
            get { return this.subItems; }
            set { this.subItems = value; }
        }
    }
}
