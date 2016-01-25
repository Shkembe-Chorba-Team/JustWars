namespace JustWars.Web.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JustWarsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(JustWarsDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            SeedData seedData = new SeedData();
            context.Users.AddOrUpdate(seedData.Users.ToArray());
            context.Items.AddOrUpdate(seedData.Items.ToArray());
            context.Battles.AddOrUpdate(seedData.Battles.ToArray());
        }
    }
}
