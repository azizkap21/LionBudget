using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lion.DAL.Abstract;
using Lion.Domain.Models;

namespace Lion.DAL.Concrete
{
    class LedgerAccountRepositiry:GenericRepository<LedgerAccount>,ILedgerAccountRepository
    {
        public LedgerAccount GetLedgerAccount(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.LedgerAccountID == id);
        }

        public void PreCache()
        {
            throw new NotImplementedException();
        }

        public void AddToCache(LedgerAccount ledgerAccount)
        {
            throw new NotImplementedException();
        }
    }
}
