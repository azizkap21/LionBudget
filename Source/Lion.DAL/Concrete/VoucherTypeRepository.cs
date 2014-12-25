using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lion.DAL.Abstract;
using Lion.Domain.Models;

namespace Lion.DAL.Concrete
{
    public class VoucherTypeRepository:GenericRepository<VoucherType>,IVoucherTypeRepository
    {
        public VoucherType GetVoucherType(short id)
        {
            return GetAll().FirstOrDefault(x => x.VoucherTypeID == id);
        }
    }
}
