using Lion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lion.DAL.Abstract
{
    public interface ILedgerAccountAddressRepository : IGenericRepository<LedgerAccountAddress>
    {
        LedgerAccountAddress GetAccountAddress(Guid id);
        
    }
}
