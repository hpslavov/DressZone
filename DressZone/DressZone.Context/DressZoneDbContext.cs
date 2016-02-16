namespace DressZone.Context
{
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.Account;
    using Models.Shop;
    using System.Data.Entity;
    using System.Linq;
    public class DressZoneDbContext : IdentityDbContext<User>, IDressZoneDbContext
    {
        public DressZoneDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            
        }

        public static DressZoneDbContext Create()
        {
            return new DressZoneDbContext();
        }

        public IDbSet<User> GetAllUsers()
        {
            return this.Users;
        }

        public virtual IDbSet<GenderType> GenderTypes { get; set; }

        public virtual IDbSet<Color> Colors { get; set; }

        public virtual IDbSet<Size> Sizes { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<CategoryImage> CategoryImages { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<ProductImage> ProductImages { get; set; }

        public virtual IDbSet<Review> Reviews { get; set; }

        public virtual IDbSet<WishList> WishLists { get; set; }

        public virtual IDbSet<WishListItem> WishListItems { get; set; }

        public virtual IDbSet<CartSubItem> CartSubItems { get; set; }

        public virtual IDbSet<Cart> Carts { get; set; }

        public virtual IDbSet<Shipping> Shippings { get; set; }

    }
}
