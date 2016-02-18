
namespace DressZone.Services.Admin
{
    using System;
    using System.Linq;
    using DressZone.Services.Contracts;
    using Models.Account;
    using Repository.Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AdminUserService : IAdminUserService
    {
        private IGenericRepository<User> users;
        private IGenericRepository<IdentityRole> roles;

        public AdminUserService(IGenericRepository<User> repo,IGenericRepository<IdentityRole> roles)
        {
            this.users = repo;
            this.roles = roles;
        }

        public User Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAll()
        {
            var usersFromDb = this.users.All();
            return usersFromDb;
        }

        public User GetByName(string email)
        {
            var resultUser = this.users.All().Where(x => x.Email == email).FirstOrDefault();
            return resultUser;
        }

        public string GetRole(string name)
        {
            var user = this.GetByName(name);
            var userRoleName = user.Roles.ToList()[0].RoleId;
            var userRoles = this.roles.All().Where(r => r.Id == userRoleName).ToList();
            var result = userRoles[0].Name;
            return result;
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
