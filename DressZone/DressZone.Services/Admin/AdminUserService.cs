
namespace DressZone.Services.Admin
{
    using System;
    using System.Linq;
    using DressZone.Services.Contracts;
    using Models.Account;
    using Repository.Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
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
            user.IsDeleted = true;
            user.ModifiedOn = DateTime.Now;
            user.DeletedOn = DateTime.Now;
            this.users.PartialModifiedUpdated(user);
            this.users.SaveChanges();
            return user;
        }

        public IQueryable<User> GetAll()
        {
            var usersFromDb = this.users.All();
            return usersFromDb;
        }

        public User GetByEmail(string email)
        {
            var resultUser = this.users.All().Where(x => x.Email == email).FirstOrDefault();
            return resultUser;
        }

        public IQueryable<IdentityRole> GetAllRolesOfUser(string userId)
        {
            var user = this.users.GetById(userId);
            var rolesId = user.Roles.Select(r => r.RoleId).ToList();
            var roleEntities = new List<IdentityRole>();
            foreach (var id in rolesId)
            {
                var current = GetRoleEntity(id);
                roleEntities.Add(current);
            }

            return roleEntities.AsQueryable();
        }

        public IdentityRole GetRole(string userEmail)
        {
            var user = this.GetByEmail(userEmail);  
            var userRoleId = user.Roles.ToList()[0].RoleId;
            var result = this.roles.All().Where(r => r.Id == userRoleId).ToList()[0];
            return result;
        }

        public IdentityRole GetRoleEntity(string Id)
        {
            var currentRole = this.roles.All().Where(r => r.Id == Id).FirstOrDefault();
            
            return currentRole;
        }

        public User EditUser(User user)
        {
            user.ModifiedOn = DateTime.Now;
            this.users.PartialModifiedUpdated(user);
            this.users.SaveChanges();
            return user;
        }

        public User Create(User user)
        {
            return null;
        }
    }
}
