using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lion.Domain.Models;
using Lion.DAL.Abstract;

namespace Lion.DAL.Concrete
{
    public class LedgerAccountAddressRepository:GenericRepository<LedgerAccountAddress>, ILedgerAccountAddressRepository
    {

       

        public LedgerAccountAddress GetAccountAddress(Guid id)
        {
            return this.GetAll().Where(x => x.LedgerAccountAddressID == id).FirstOrDefault();

        }
    }
}
