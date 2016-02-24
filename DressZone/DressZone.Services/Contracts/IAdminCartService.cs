namespace DressZone.Services.Contracts
{
    using DressZone.Models.Account;
    using Models.Shop;
    using System.Linq;
    public interface IAdminCartService
    {
        void CreateInitialUserCart(string userName);
        IQueryable<Cart> AllCarts();
        Cart UpdateCart(Cart cart);
        void DeleteCart(Cart cart);
    }
}
