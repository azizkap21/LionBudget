using Lion.DAL.Abstract;
using Lion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lion.DAL.Concrete
{
    /// <summary>
    /// Type of address
    /// </summary>
    public class AddressTypeRepository : GenericRepository<AddressType>, IAddressTypeRepository
    {

        /// <summary>
        /// Get AddresType by id
        /// </summary>
        /// <param name="id">integer AddressTypeId paremeter</param>
        /// <returns></returns>
        public AddressType GetAddressType(short id)
        {
            return GetAll().Where(x => x.AddressTypeID == id).FirstOrDefault();
        }
    }
}
