namespace DressZone.Context
{
    using DressZone.Models.Account;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class DressZoneDbContext : IdentityDbContext<User>
    {
        public DressZoneDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static DressZoneDbContext Create()
        {
            return new DressZoneDbContext();
        }
    }
}
