namespace DressZone.Models.Shop
{
    using Common.Contracts;
    using DressZone.Models.Shop.Common;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    public class ProductImage
    {
        ProductImage()
        {
            this.CreatedOn = DateTime.Now;
        }
        public int Id { get; set; }
        [Column("Product Name")]
        public string ProductName { get; set; }
        public string FileName { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
