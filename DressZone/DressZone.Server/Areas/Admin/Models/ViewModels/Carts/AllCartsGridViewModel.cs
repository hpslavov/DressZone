namespace DressZone.Server.Areas.Admin.Models.ViewModels.Carts
{
    using DressZone.Models.Account;
    using DressZone.Models.Shop;
    using DressZone.Server.Infrastructure.Mapping.Contracts;
    using System;
    using System.Collections.Generic;
    public class AllCartsGridViewModel : IMapFrom<Cart>,IMapTo<Cart>
    {
        private ICollection<CartSubItem> subItems;

        public AllCartsGridViewModel()
        {
            this.subItems = new List<CartSubItem>();
        }

        public string Id { get; set; }

        public bool? IsCheckedOut { get; set; }

        public decimal? SubTotal { get; set; }

        public int? ShippingId { get; set; }

        public decimal? Total { get; set; }

        public ICollection<CartSubItem> SubItems
        {
            get { return this.subItems; }
            set { this.subItems = value; }
        }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}