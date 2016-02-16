namespace DressZone.Models.Shop
{
    using DressZone.Models.Shop.Common;
    using System.ComponentModel.DataAnnotations.Schema;
    public class ProductImage : BaseModel
    {
        ProductImage() : base()
        {

        }

        [Column("Product Name")]
        public string ProductName { get; set; }
        public string FileName { get; set; }
    }
}
