using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lion.Domain.Models
{
    public class LionBudgetDBContext : DbContext
    {
        public LionBudgetDBContext()
            : base("LionBudgetDBcontext")
        {

        }

       

        public DbSet<LedgerAccountAddress> AccountAddress { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<Budget> Budget { get; set; }
        public DbSet<CountryDetail> CountryDetail { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<LedgerAccount> LedgerAccount { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestion { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<UserAccountAddress> UserAddress { get; set; }
        public DbSet<UserStatus> UserStatus { get; set; }
        public DbSet<VoucherHeader> VoucherHeader { get; set; }
        public DbSet<VoucherDetail> VoucherDetail { get; set; }
        public DbSet<VoucherType> VoucherType { get; set; }

        
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        ////For Table Mapping 
            
        //    modelBuilder.Entity<Budget>().ToTable("tblBudget");

        ////For Preventing Table Creation
        //    modelBuilder.Ignore<UserAccount>();


        //    //For multiple keys
        //    modelBuilder.Entity<VoucherDetail>().HasKey(x => new { x.VoucherHeaderID, x.VoucherDetailID });
            
        //    base.OnModelCreating(modelBuilder);


        //}
    }
}
