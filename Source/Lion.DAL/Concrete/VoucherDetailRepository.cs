using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lion.DAL.Abstract;
using Lion.Domain.Models;

namespace Lion.DAL.Concrete
{
    public class VoucherDetailRepository:GenericRepository<VoucherDetail>,IVoucherDetailRepository
    {
        public VoucherDetail GetVoucherDetail(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.VoucherDetailID == id);
        }
    }
}
