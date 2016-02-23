namespace DressZone.Services.Admin
{
    using DressZone.Services.Contracts;
    using Models.Account;
    using Models.Shop;
    using Repository.Contracts;
    using System;
    using System.Linq;

    public class AdminCartService :IAdminCartService
    {
        private IGenericRepository<Cart> cartRepository;
        private IGenericRepository<User> usersRepository;


        public AdminCartService(IGenericRepository<Cart> cartRepo, IGenericRepository<User> usersRepo)
        {
            this.cartRepository = cartRepo;
            this.usersRepository = usersRepo;
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
    }
}
