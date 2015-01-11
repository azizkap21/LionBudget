namespace Lion.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class liondomainmigrationsconfiguration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserAddresses", newName: "UserAccountAddresses");
            DropForeignKey("dbo.AccountAddresses", "AddressTypeId", "dbo.AddressTypes");
            DropForeignKey("dbo.AccountAddresses", "CountryID", "dbo.CountryDetails");
            DropForeignKey("dbo.AccountAddresses", "UserAccount_UserAccountID", "dbo.UserAccounts");
            DropIndex("dbo.AccountAddresses", new[] { "AddressTypeId" });
            DropIndex("dbo.AccountAddresses", new[] { "CountryID" });
            DropIndex("dbo.AccountAddresses", new[] { "UserAccount_UserAccountID" });
            DropPrimaryKey("dbo.UserAccountAddresses");
            CreateTable(
                "dbo.LedgerAccountAddresses",
                c => new
                    {
                        LedgerAccountAddressID = c.Guid(nullable: false),
                        LedgerAccountID = c.Guid(nullable: false),
                        AddressTypeID = c.Short(nullable: false),
                        AddressLine1 = c.String(nullable: false, maxLength: 100),
                        AddressLine2 = c.String(maxLength: 100),
                        City = c.String(nullable: false, maxLength: 50),
                        PostCode = c.String(nullable: false, maxLength: 15),
                        State = c.String(maxLength: 50),
                        CountryID = c.Short(nullable: false),
                        UserAccount_UserAccountID = c.Guid(),
                    })
                .PrimaryKey(t => t.LedgerAccountAddressID)
                .ForeignKey("dbo.AddressTypes", t => t.AddressTypeID, cascadeDelete: true)
                .ForeignKey("dbo.CountryDetails", t => t.CountryID, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_UserAccountID)
                .Index(t => t.AddressTypeID)
                .Index(t => t.CountryID)
                .Index(t => t.UserAccount_UserAccountID);
            
            AddColumn("dbo.VoucherHeaders", "UserAccountID", c => c.Guid(nullable: false));
            AddColumn("dbo.UserAccountAddresses", "UserAccountAddressID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.UserAccountAddresses", "UserAccountAddressID");
            DropColumn("dbo.UserAccountAddresses", "UserAddressID");
            DropTable("dbo.AccountAddresses");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.AccountAddressID);
            
            AddColumn("dbo.UserAccountAddresses", "UserAddressID", c => c.Guid(nullable: false));
            DropForeignKey("dbo.LedgerAccountAddresses", "UserAccount_UserAccountID", "dbo.UserAccounts");
            DropForeignKey("dbo.LedgerAccountAddresses", "CountryID", "dbo.CountryDetails");
            DropForeignKey("dbo.LedgerAccountAddresses", "AddressTypeID", "dbo.AddressTypes");
            DropIndex("dbo.LedgerAccountAddresses", new[] { "UserAccount_UserAccountID" });
            DropIndex("dbo.LedgerAccountAddresses", new[] { "CountryID" });
            DropIndex("dbo.LedgerAccountAddresses", new[] { "AddressTypeID" });
            DropPrimaryKey("dbo.UserAccountAddresses");
            DropColumn("dbo.UserAccountAddresses", "UserAccountAddressID");
            DropColumn("dbo.VoucherHeaders", "UserAccountID");
            DropTable("dbo.LedgerAccountAddresses");
            AddPrimaryKey("dbo.UserAccountAddresses", "UserAddressID");
            CreateIndex("dbo.AccountAddresses", "UserAccount_UserAccountID");
            CreateIndex("dbo.AccountAddresses", "CountryID");
            CreateIndex("dbo.AccountAddresses", "AddressTypeId");
            AddForeignKey("dbo.AccountAddresses", "UserAccount_UserAccountID", "dbo.UserAccounts", "UserAccountID");
            AddForeignKey("dbo.AccountAddresses", "CountryID", "dbo.CountryDetails", "CountryID", cascadeDelete: true);
            AddForeignKey("dbo.AccountAddresses", "AddressTypeId", "dbo.AddressTypes", "AddressTypeID", cascadeDelete: true);
            RenameTable(name: "dbo.UserAccountAddresses", newName: "UserAddresses");
        }
    }
}
