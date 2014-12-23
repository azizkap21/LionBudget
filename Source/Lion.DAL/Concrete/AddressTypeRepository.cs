using Lion.DAL.Abstract;
using Lion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lion.DAL.Concrete
{
    public class AddressTypeRepository : GenericRepository<AddressType>, IAddressTypeRepository
    {

        public AddressTypeRepository(string connectionString)
            : base(connectionString)
        {

        }

        public AddressType GetAddressType(short id)
        {
            return GetAll().Where(x => x.AddressTypeID == id).FirstOrDefault();
        }
    }
}
