namespace DressZone.Services.Contracts
{
    using DressZone.Models.Account;

    public interface IAdminCartService
    {
        void CreateInitialUserCart(string userName);
    }
}
