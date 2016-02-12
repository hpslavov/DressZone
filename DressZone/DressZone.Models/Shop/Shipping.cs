namespace DressZone.Models.Shop
{
    using DressZone.Models.Shop.Common;

    public class Shipping : BaseModel
    {
        public Shipping():base()
        {

        }

        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public decimal Fee { get; set; }
    }
}
