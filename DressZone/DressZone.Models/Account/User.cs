namespace DressZone.Models.Account
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Shop.Common.Contracts;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System;
    using Shop;
    using System.ComponentModel.DataAnnotations.Schema;
    public class User : IdentityUser
    {
        public DateTime? CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }
         
        public virtual Cart Cart { get; set; }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
