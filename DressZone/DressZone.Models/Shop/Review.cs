namespace DressZone.Models.Shop
{
    using DressZone.Models.Shop.Common;

    public class Review : BaseModel
    {
        public Review():base()
        {

        }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int Rating { get; set; }

        public string Description { get; set; }

        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}