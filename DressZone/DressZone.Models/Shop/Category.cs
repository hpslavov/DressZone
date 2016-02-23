namespace DressZone.Models.Shop
{
    using Common.Contracts;
    using DressZone.Models.Shop.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Category 
    {
        private ICollection<CategoryImage> images;

        public Category()
        {
            this.images = new List<CategoryImage>();
            this.CreatedOn = DateTime.Now;
        }
        public int Id { get; set; }
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public string FrontImageName { get; set; }

        public virtual ICollection<CategoryImage> Images
        {
            get
            {
                return this.images;
            }
            set
            {
                this.images = value;
            }
        }

        public DateTime? CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
