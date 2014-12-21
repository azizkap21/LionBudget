using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lion.Domain.Models;
using Lion.DAL.Abstract;

namespace Lion.DAL.Concrete
{
    public class AccountAddressRepository:GenericRepository<AccountAddress>, IAccountAddressRepository
    {

        public AccountAddress GetAccountAddress(Guid id)
        {
            return this.GetAll().Where(x => x.AccountID == id).FirstOrDefault();

        }
    }
}
