namespace DressZone.Models.Shop
{
    using Common.Contracts;
    using DressZone.Models.Shop.Common;
    using System.Collections.Generic;
    using System;

    public class CartSubItem
    {
        private ICollection<Product> products;

        public CartSubItem()
        {
            this.products = new List<Product>();
        }
        public int Id { get; set; }
        public int Quantity { get; set; }

        public decimal CartSubItemTotal { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
