namespace DressZone.Models.Shop
{
    using DressZone.Models.Shop.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Category : BaseModel
    {

        public string Description { get; set; }

        [Required]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public string FrontImageName { get; set; }
    }
}
