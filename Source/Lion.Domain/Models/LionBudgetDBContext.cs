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
        public LionBudgetDBContext(string connectionString)
            : base(connectionString)
        {

        }

        public LionBudgetDBContext()
        {

        }

        public DbSet<AccountAddress> AccountAddress { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<Budget> Budget { get; set; }
        public DbSet<CountryDetail> CountryDetail { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<LedgerAccount> LedgerAccount { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestion { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        public DbSet<UserStatus> UserStatus { get; set; }
        public DbSet<VoucherHeader> VoucherHeader { get; set; }
        public DbSet<VoucherDetail> VoucherDetail { get; set; }
        public DbSet<VoucherType> VoucherType { get; set; }

    }
}
