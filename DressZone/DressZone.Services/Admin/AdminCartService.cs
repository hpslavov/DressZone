namespace DressZone.Services.Admin
{
    using DressZone.Services.Contracts;
    using Models.Account;
    using Models.Shop;
    using Repository.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminCartService : IAdminCartService
    {
        private IGenericRepository<Cart> cartRepository;
        private IGenericRepository<User> usersRepository;
        

        public AdminCartService(IGenericRepository<Cart> cartRepo, IGenericRepository<User> usersRepo)
        {
            this.cartRepository = cartRepo;
            this.usersRepository = usersRepo;
        }

        public IQueryable<Cart> AllCarts()
        {
            var allCarts = this.usersRepository
                .All()
                .Where(x => x.IsDeleted != true && x.Cart.IsDeleted != true)
                .Select(x => x.Cart).ToList();
            var resultList = new List<Cart>();

            for (int i = 0; i < allCarts.Count; i++)
            {
                if (i != 0 || allCarts[i] != null)
                {
                    resultList.Add(allCarts[i]);
                }

            }
            return resultList.AsQueryable();
        }

        public Cart GetCart(string id)
        {
            var cartToReturn = this.cartRepository.GetById(id);
            return cartToReturn;
        }

        public void CreateInitialUserCart(string UserName)
        {
            var user = usersRepository.All().Where(x => x.UserName == UserName).FirstOrDefault();

            var cart = new Cart
            {
                User = user,
                Total = 0.0m,
                SubTotal = 0.0m,
                CreatedOn = DateTime.Now
            };
            cartRepository.Add(cart);
            cartRepository.SaveChanges();
        }

        public Cart UpdateCart(Cart cart)
        {
            cart.ModifiedOn = DateTime.Now;
            this.cartRepository.PartialModifiedUpdated(cart);
            this.cartRepository.SaveChanges();
            var result=  this.GetCart(cart.Id);
            return result;
        }

        public void DeleteCart(Cart cart)
        {
            cart.DeletedOn = DateTime.Now;
            cart.IsDeleted = true;
            this.cartRepository.PartialModifiedUpdated(cart);
            this.cartRepository.SaveChanges();
        }
    }
}
