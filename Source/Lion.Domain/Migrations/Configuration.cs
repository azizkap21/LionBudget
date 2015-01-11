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
                new AddressType { AddressTypeID = 1, Description = "Mailing Address", Name = "MailingAddress" },
                new AddressType { AddressTypeID = 2, Description = "Billing Address", Name = "BillingAddress" },
                new AddressType { AddressTypeID = 3, Description = "Home Address", Name = "HomeAddress" });

            context.Currency.AddOrUpdate(
                new Currency { CurrencyID = 1, Description = "US Dollar", CurrencyCode = "USD", CurrencySymbol = "$" },
                new Currency { CurrencyID = 2, Description = "Indian Rupees", CurrencyCode = "INR", CurrencySymbol = "" },
                new Currency { CurrencyID = 3, Description = "British Pound", CurrencyCode = "GBP", CurrencySymbol = "£" });

            context.SecurityQuestion.AddOrUpdate(

                new SecurityQuestion { SecurityQuestionID = 1, Question = "Your favourite colour" },
                new SecurityQuestion { SecurityQuestionID = 2, Question = "Your mother's maiden name" },
                new SecurityQuestion { SecurityQuestionID = 1, Question = "Your date of birth" },
                new SecurityQuestion { SecurityQuestionID = 1, Question = "Your first school name" },
                new SecurityQuestion { SecurityQuestionID = 1, Question = "Your first pet's name" },
                new SecurityQuestion { SecurityQuestionID = 1, Question = "Your favourite city" },
                new SecurityQuestion { SecurityQuestionID = 1, Question = "Your travel destination" },
                new SecurityQuestion { SecurityQuestionID = 1, Question = "Your place of birth" },
                new SecurityQuestion { SecurityQuestionID = 1, Question = "Your memorable word" }
                );

            context.UserStatus.AddOrUpdate(

                new UserStatus { UserStatusID = 1, Description = "Active", Name = "Active" },
                new UserStatus { UserStatusID = 2, Description = "Locked", Name = "Locked" },
                new UserStatus { UserStatusID = 3, Description = "Demo", Name = "Demo" }
                );

            context.VoucherType.AddOrUpdate(
                new VoucherType { VoucherTypeID = 1, Description = "Expense Voucher", Name = "Expense" },
                new VoucherType { VoucherTypeID = 2, Description = "Income Voucher", Name = "Income" }
                );

       
        }
    }
}
