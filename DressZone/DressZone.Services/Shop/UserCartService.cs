using DressZone.Models.Account;
using DressZone.Models.Shop;
using DressZone.Repository.Contracts;
using DressZone.Services.Contracts;
using System;

namespace DressZone.Services.Shop
{
   public class UserCartService : IUserCartService
    {
        private IGenericRepository<User> userRepo;
        private IGenericRepository<Cart> cartsRepo;

        private IGenericRepository<Product> products;
        private IGenericRepository<CartSubItem> subItems;

        public UserCartService(IGenericRepository<User> userRepo,
                               IGenericRepository<CartSubItem> subItems,
                               IGenericRepository<Product> products,
                               IGenericRepository<Cart> cartsRepo)
        {
            this.userRepo = userRepo;
            this.subItems = subItems;
            this.products = products;
            this.cartsRepo = cartsRepo;
        }

        public Cart GetUserCart(string userId)
        {
            var cart = this.userRepo.GetById(userId).Cart;
            return cart;
        }

        public void AddItemToCart(string productId,string cartId)
        {
            var id = int.Parse(productId);
            var prFromDb = this.products.GetById(id);
            var currentCart = this.userRepo.GetById(cartId);

            var subCartItem = new CartSubItem
            {
                Quantity = 1,
                CartSubItemTotal = prFromDb.Price
            };
            this.subItems.Add(subCartItem);
            this.subItems.SaveChanges();
            var subTotal = 0.0m;
            foreach (var item in currentCart.Cart.SubItems)
            {
                subTotal += item.CartSubItemTotal;
            }

            prFromDb.IsInCart = true;
            currentCart.Cart.SubTotal = subTotal;
            currentCart.Cart.SubItems.Add(subCartItem);
            this.cartsRepo.PartialModifiedUpdated(currentCart.Cart);
            this.cartsRepo.SaveChanges();
            this.products.PartialModifiedUpdated(prFromDb);
            this.products.SaveChanges();
        }

    }
}
