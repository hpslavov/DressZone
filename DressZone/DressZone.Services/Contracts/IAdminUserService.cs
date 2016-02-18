namespace DressZone.Services.Contracts
{
    using Models.Account;
    using System.Linq;

    public interface IAdminUserService
    {
        IQueryable<User> GetAll();
        User GetByName(string email);
        User Update(User user);
        User Delete(User user);
        string GetRole(string id);
    }
}
