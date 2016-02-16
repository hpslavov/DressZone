namespace DressZone.Models.Shop
{
    using Common.Contracts;
    using DressZone.Models.Shop.Common;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class Product
    {
        private ICollection<Color> colors;
        private ICollection<ProductImage> images;
        private ICollection<Review> reviews;

        public Product()
        {
            this.colors = new HashSet<Color>();
            this.images = new HashSet<ProductImage>();
            this.reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int? GenderId { get; set; }

        public virtual GenderType Gender { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int? SizeId { get; set; }

        public virtual Size Size { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Color> Colors
        {
            get { return this.colors; }
            set { this.colors = value; }
        }

        public bool IsInCart { get; set; }

        public int Discount { get; set; }

        public int Rating { get; set; }

        public virtual ICollection<ProductImage> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }
    }
}
