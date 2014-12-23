namespace Lion.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LionBudgetDBContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountAddresses",
                c => new
                    {
                        AccountAddressID = c.Guid(nullable: false),
                        AccountID = c.Guid(nullable: false),
                        AddressTypeId = c.Short(nullable: false),
                        AddressLine1 = c.String(nullable: false, maxLength: 100),
                        AddressLine2 = c.String(maxLength: 100),
                        City = c.String(nullable: false, maxLength: 50),
                        PostCode = c.String(nullable: false, maxLength: 15),
                        State = c.String(maxLength: 50),
                        CountryID = c.Short(nullable: false),
                        UserAccount_UserAccountID = c.Guid(),
                    })
                .PrimaryKey(t => t.AccountAddressID)
                .ForeignKey("dbo.AddressTypes", t => t.AddressTypeId, cascadeDelete: true)
                .ForeignKey("dbo.CountryDetails", t => t.CountryID, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_UserAccountID)
                .Index(t => t.AddressTypeId)
                .Index(t => t.CountryID)
                .Index(t => t.UserAccount_UserAccountID);
            
            CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        AddressTypeID = c.Short(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                        Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AddressTypeID);
            
            CreateTable(
                "dbo.CountryDetails",
                c => new
                    {
                        CountryID = c.Short(nullable: false, identity: true),
                        CountryName = c.String(nullable: false, maxLength: 25),
                        CountryCode = c.String(nullable: false, maxLength: 5),
                        ISDCode = c.String(maxLength: 5),
                        CurrencyID = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.CountryID)
                .ForeignKey("dbo.Currencies", t => t.CurrencyID, cascadeDelete: true)
                .Index(t => t.CurrencyID);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        CurrencyID = c.Short(nullable: false, identity: true),
                        CurrencyCode = c.String(nullable: false, maxLength: 3),
                        CurrencySymbol = c.String(maxLength: 1),
                        Description = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.CurrencyID);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserAccountID = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 20),
                        SecurityQuestionID = c.Short(nullable: false),
                        SecretAnswer = c.String(nullable: false, maxLength: 50),
                        UserStatusID = c.Short(nullable: false),
                        Contact1 = c.String(nullable: false, maxLength: 25),
                        Contact2 = c.String(maxLength: 25),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserAccountID)
                .ForeignKey("dbo.SecurityQuestions", t => t.SecurityQuestionID, cascadeDelete: true)
                .ForeignKey("dbo.UserStatus", t => t.UserStatusID, cascadeDelete: true)
                .Index(t => t.SecurityQuestionID)
                .Index(t => t.UserStatusID);
            
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        BudgetID = c.Guid(nullable: false),
                        LedgerAccountID = c.Guid(nullable: false),
                        BudgetAmount = c.Int(nullable: false),
                        BudgetPeriod = c.Short(nullable: false),
                        UserAccount_UserAccountID = c.Guid(),
                    })
                .PrimaryKey(t => t.BudgetID)
                .ForeignKey("dbo.LedgerAccounts", t => t.LedgerAccountID, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_UserAccountID)
                .Index(t => t.LedgerAccountID)
                .Index(t => t.UserAccount_UserAccountID);
            
            CreateTable(
                "dbo.LedgerAccounts",
                c => new
                    {
                        LedgerAccountID = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        LedgerAccountName = c.String(nullable: false, maxLength: 15),
                        CrDr = c.String(maxLength: 1),
                        Description = c.String(maxLength: 50),
                        ParentAccountID = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.LedgerAccountID);
            
            CreateTable(
                "dbo.SecurityQuestions",
                c => new
                    {
                        SecurityQuestionID = c.Short(nullable: false, identity: true),
                        Question = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.SecurityQuestionID);
            
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        UserAddressID = c.Guid(nullable: false),
                        UserAccountID = c.Guid(nullable: false),
                        AddressType = c.Short(nullable: false),
                        AddressLine1 = c.String(nullable: false, maxLength: 100),
                        AddressLine2 = c.String(maxLength: 100),
                        City = c.String(nullable: false, maxLength: 50),
                        PostCode = c.String(nullable: false, maxLength: 15),
                        State = c.String(maxLength: 50),
                        CountryID = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.UserAddressID)
                .ForeignKey("dbo.CountryDetails", t => t.CountryID, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccountID, cascadeDelete: true)
                .Index(t => t.UserAccountID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.UserStatus",
                c => new
                    {
                        UserStatusID = c.Short(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                        Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.UserStatusID);
            
            CreateTable(
                "dbo.VoucherDetails",
                c => new
                    {
                        VoucherDetailID = c.Guid(nullable: false),
                        VoucherHeaderID = c.Guid(nullable: false),
                        Item = c.String(nullable: false, maxLength: 50),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LedgerAccountID = c.Guid(nullable: false),
                        Volume = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VolumeMeasure = c.String(maxLength: 5),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VoucherDetailID)
                .ForeignKey("dbo.LedgerAccounts", t => t.LedgerAccountID, cascadeDelete: true)
                .ForeignKey("dbo.VoucherHeaders", t => t.VoucherHeaderID, cascadeDelete: true)
                .Index(t => t.VoucherHeaderID)
                .Index(t => t.LedgerAccountID);
            
            CreateTable(
                "dbo.VoucherHeaders",
                c => new
                    {
                        VoucherHeaderID = c.Guid(nullable: false),
                        VoucherTypeID = c.Short(nullable: false),
                        VoucherDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 250),
                        CrDr = c.String(nullable: false, maxLength: 1),
                        Place = c.String(maxLength: 25),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VoucherHeaderID)
                .ForeignKey("dbo.VoucherTypes", t => t.VoucherTypeID, cascadeDelete: true)
                .Index(t => t.VoucherTypeID);
            
            CreateTable(
                "dbo.VoucherTypes",
                c => new
                    {
                        VoucherTypeID = c.Short(nullable: false, identity: true),
                        Name = c.String(maxLength: 15),
                        Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.VoucherTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VoucherHeaders", "VoucherTypeID", "dbo.VoucherTypes");
            DropForeignKey("dbo.VoucherDetails", "VoucherHeaderID", "dbo.VoucherHeaders");
            DropForeignKey("dbo.VoucherDetails", "LedgerAccountID", "dbo.LedgerAccounts");
            DropForeignKey("dbo.AccountAddresses", "UserAccount_UserAccountID", "dbo.UserAccounts");
            DropForeignKey("dbo.UserAccounts", "UserStatusID", "dbo.UserStatus");
            DropForeignKey("dbo.UserAddresses", "UserAccountID", "dbo.UserAccounts");
            DropForeignKey("dbo.UserAddresses", "CountryID", "dbo.CountryDetails");
            DropForeignKey("dbo.UserAccounts", "SecurityQuestionID", "dbo.SecurityQuestions");
            DropForeignKey("dbo.Budgets", "UserAccount_UserAccountID", "dbo.UserAccounts");
            DropForeignKey("dbo.Budgets", "LedgerAccountID", "dbo.LedgerAccounts");
            DropForeignKey("dbo.AccountAddresses", "CountryID", "dbo.CountryDetails");
            DropForeignKey("dbo.CountryDetails", "CurrencyID", "dbo.Currencies");
            DropForeignKey("dbo.AccountAddresses", "AddressTypeId", "dbo.AddressTypes");
            DropIndex("dbo.VoucherHeaders", new[] { "VoucherTypeID" });
            DropIndex("dbo.VoucherDetails", new[] { "LedgerAccountID" });
            DropIndex("dbo.VoucherDetails", new[] { "VoucherHeaderID" });
            DropIndex("dbo.UserAddresses", new[] { "CountryID" });
            DropIndex("dbo.UserAddresses", new[] { "UserAccountID" });
            DropIndex("dbo.Budgets", new[] { "UserAccount_UserAccountID" });
            DropIndex("dbo.Budgets", new[] { "LedgerAccountID" });
            DropIndex("dbo.UserAccounts", new[] { "UserStatusID" });
            DropIndex("dbo.UserAccounts", new[] { "SecurityQuestionID" });
            DropIndex("dbo.CountryDetails", new[] { "CurrencyID" });
            DropIndex("dbo.AccountAddresses", new[] { "UserAccount_UserAccountID" });
            DropIndex("dbo.AccountAddresses", new[] { "CountryID" });
            DropIndex("dbo.AccountAddresses", new[] { "AddressTypeId" });
            DropTable("dbo.VoucherTypes");
            DropTable("dbo.VoucherHeaders");
            DropTable("dbo.VoucherDetails");
            DropTable("dbo.UserStatus");
            DropTable("dbo.UserAddresses");
            DropTable("dbo.SecurityQuestions");
            DropTable("dbo.LedgerAccounts");
            DropTable("dbo.Budgets");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Currencies");
            DropTable("dbo.CountryDetails");
            DropTable("dbo.AddressTypes");
            DropTable("dbo.AccountAddresses");
        }
    }
}
