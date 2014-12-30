
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lion.DAL.Abstract;
using Lion.Domain.Models;

namespace Lion.DAL.Concrete
{
    public class UserAccountAddressRespository:GenericRepository<UserAccountAddress>,IUserAccountAddressRepository
    {
        public UserAccountAddress GetUserAddress(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.UserAccountAddressID == id);
        }
    }
}
