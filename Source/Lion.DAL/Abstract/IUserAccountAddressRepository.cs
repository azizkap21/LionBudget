using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lion.Domain.Models;

namespace Lion.DAL.Abstract
{
    public interface IUserAccountAddressRepository:IGenericRepository<UserAccountAddress>
    {
        UserAccountAddress GetUserAddress(Guid id);
    }
}
