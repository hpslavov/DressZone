namespace DressZone.Server.Models.DTO.ProductDetails
{
    using DressZone.Models.Shop;
    using Infrastructure.Mapping.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class SingleProductDTO : IMapFrom<Product>
    {
        private ICollection<Color> colors;
        private ICollection<ProductImage> images;
        private ICollection<Size> sizes;
        private ICollection<Review> reviews;

        public SingleProductDTO()
        {
            this.colors = new HashSet<Color>();
            this.images = new HashSet<ProductImage>();
            this.reviews = new HashSet<Review>();
            this.sizes = new HashSet<Size>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int? GenderId { get; set; }

        public virtual GenderType Gender { get; set; }

        public int? CategoryId { get; set; }

        public  Category Category { get; set; }

        public  ICollection<Size> Sizes
        {
            get { return this.sizes; }
            set { this.sizes = value; }
        }

        public ICollection<Color> Colors
        {
            get { return this.colors; }
            set { this.colors = value; }
        }

        public bool IsInCart { get; set; }

        public int Discount { get; set; }

        public int Rating { get; set; }

        public  ICollection<ProductImage> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public  ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }
    }
}