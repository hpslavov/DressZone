namespace DressZone.Context
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.Account;

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
