namespace DressZone.Server.Areas.Admin.Models.ViewModels.Users
{
    using DressZone.Models.Account;
    using DressZone.Models.Shop;
    using DressZone.Server.Infrastructure.Mapping.Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    public class GridViewUserViewModel : IMapFrom<User>, IMapTo<User>
    {
        public string Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool IsDeleted { get; set; }
        public string Role { get; set; }
    }
}