namespace Lion.Domain.Migrations
{
    using Lion.Domain.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lion.Domain.Models.LionBudgetDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LionBudgetDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //LionBudgetDBContext context = new LionBudgetDBContext();

            context.AddressType.AddOrUpdate(
                new AddressType { AddressTypeID= 1, Description="Mailing Address", Name="MailingAddress"},
                new AddressType { AddressTypeID= 2, Description="Billing Address", Name="BillingAddress"});
        }
    }
}
