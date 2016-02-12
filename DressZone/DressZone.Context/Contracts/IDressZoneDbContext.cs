namespace DressZone.Context.Contracts
{
    using DressZone.Models.Shop;
    using Models.Account;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    public interface IDressZoneDbContext : IDisposable
    {
        int SaveChanges();

        IQueryable<User> DbUsers { get; set; }

        IDbSet<GenderType> GenderTypes { get; set; }

        IDbSet<Color> Colors { get; set; }

        IDbSet<Size> Sizes { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<CategoryImage> CategoryImages { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<ProductImage> ProductImages { get; set; }

        IDbSet<Review> Reviews { get; set; }

        IDbSet<WishList> WishLists { get; set; }

        IDbSet<WishListItem> WishListItems { get; set; }

        IDbSet<CartSubItem> CartSubItems { get; set; }

        IDbSet<Cart> Carts { get; set; }

        IDbSet<Shipping> Shippings { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
