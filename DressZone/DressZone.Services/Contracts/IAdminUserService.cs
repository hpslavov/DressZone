namespace DressZone.Services.Contracts
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.Account;
    using System.Linq;

    public interface IAdminUserService
    {
        IQueryable<User> GetAll();
        User GetByEmail(string email);
        User EditUser(User user);
        User Delete(User user);
        IdentityRole GetRole(string userEmail);
        IdentityRole GetRoleEntity(string roleName);
        User Create(User user);
        IQueryable<IdentityRole> GetAllRolesOfUser(string userId);
    }
}
