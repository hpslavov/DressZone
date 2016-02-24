namespace DressZone.Models.Shop
{
    using Common.Contracts;
    using DressZone.Models.Shop.Common;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.IO;
    public class ProductImage
    {
        public ProductImage()
        {
            this.CreatedOn = DateTime.Now;
        }

        public int Id { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [MaxLength(200)]
        public string ContentType { get; set; }

        public bool IsFrontImage { get; set; }

        [NotMapped]
        public Stream InputStream { get; set; }

        [NotMapped]
        public int ContentLength { get; set; }

        [MaxLength(150)]
        public string FileName { get; set; }

        [MaxLength(130)]
        public string CategoryName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
