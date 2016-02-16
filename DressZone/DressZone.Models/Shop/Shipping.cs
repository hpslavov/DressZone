namespace DressZone.Models.Shop
{
    using Common.Contracts;
    using DressZone.Models.Shop.Common;
    using System;
    public class Shipping
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public decimal Fee { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
