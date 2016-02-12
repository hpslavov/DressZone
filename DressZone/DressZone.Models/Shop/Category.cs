namespace DressZone.Models.Shop
{
    using DressZone.Models.Shop.Common;
    using System;
    using System.Collections.Generic;
    public class Category : BaseModel
    {
        private ICollection<CategoryImage> images;

        public Category() : base()
        {
            this.images = new List<CategoryImage>();
        }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<CategoryImage> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
    }
}
