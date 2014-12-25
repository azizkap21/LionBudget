
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lion.DAL.Abstract;
using Lion.Domain.Models;

namespace Lion.DAL.Concrete
{
    public class UserAddressRespository:GenericRepository<UserAddress>,IUserAddressRepository
    {
        public UserAddress GetUserAddress(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.UserAddressID == id);
        }
    }
}
