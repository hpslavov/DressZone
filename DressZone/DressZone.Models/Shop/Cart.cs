namespace DressZone.Models.Shop
{
    using Account;
    using Common.Contracts;
    using DressZone.Models.Shop.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Cart
    {
        private ICollection<CartSubItem> subItems;

        public Cart()
        {
            this.Id = Guid.NewGuid().ToString().Replace("-",string.Empty);
            this.subItems = new List<CartSubItem>();
        }

        [Key, ForeignKey("User")]
        public string Id { get; set; }

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

        public DateTime? CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
