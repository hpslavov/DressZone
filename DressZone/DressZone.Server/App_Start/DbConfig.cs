namespace DressZone.Server.App_Start
{
    using Context;
    using DressZone.Context.Migrations;
    using System.Data.Entity;

    public static class DbConfig
    {
        public static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DressZoneDbContext, Configuration>());
        }
    }
}