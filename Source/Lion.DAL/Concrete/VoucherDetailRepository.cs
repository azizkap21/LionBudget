using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lion.DAL.Abstract;
using Lion.Domain.Models;
using System.Collections.Concurrent;
using System.Runtime.Caching;
using Lion.Core;

namespace Lion.DAL.Concrete
{
    public class VoucherDetailRepository:GenericRepository<VoucherDetail>,IVoucherDetailRepository
    {
        private ConcurrentDictionary<Guid, VoucherDetail> _voucherDetailCache;

        public VoucherDetail GetVoucherDetail(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.VoucherDetailID == id);
        }

        public override IQueryable<VoucherDetail> GetAll()
        {
            _voucherDetailCache = MemoryCache.Default[CommonConstants.CONST_CACHE_VOUCHER_DETAIL] as ConcurrentDictionary<Guid, VoucherDetail>;
            if (_voucherDetailCache == null || _voucherDetailCache.Count == 0)
            {
                SetvoucherDetailCache();
            }

            List<VoucherDetail> voucherDetails = _voucherDetailCache.Select(x => x.Value).ToList();

            return voucherDetails.AsQueryable();
        }

         public void PreCacheEntity()
        {
            SetvoucherDetailCache();
        }

        private void SetvoucherDetailCache()
        {
            _voucherDetailCache = new ConcurrentDictionary<Guid, VoucherDetail>();
            CacheItemPolicy policy = CachingHelper.GetCacheItemPolicy();

            List<VoucherDetail> voucherDetails = dbSet.AsQueryable().ToList();

            foreach (VoucherDetail voucher in voucherDetails)
            {
                _voucherDetailCache.TryAdd(voucher.VoucherDetailID, voucher);
            }

            MemoryCache.Default.Set(CommonConstants.CONST_CACHE_VOUCHER_DETAIL, _voucherDetailCache, policy);

        }

        public void PreCacheEntity()
        {
            SetvoucherDetailCache();
        }

        /// <summary>
        /// Re Cache User on Update or New 
        /// </summary>
        /// <param name="userAccount"></param>
        public void ReCacheVoucherDetail(VoucherDetail VoucherDetail)
        {
            _voucherDetailCache = MemoryCache.Default[CommonConstants.CONST_CACHE_VOUCHER_DETAIL] as ConcurrentDictionary<Guid, VoucherDetail>;

            if (_voucherDetailCache == null || _voucherDetailCache.Count == 0)
            {
                SetvoucherDetailCache();
            }

            if (_voucherDetailCache.ContainsKey(VoucherDetail.VoucherDetailID))
            {
                VoucherDetail oldValue = _voucherDetailCache[VoucherDetail.VoucherDetailID];
                _voucherDetailCache.TryUpdate(VoucherDetail.VoucherDetailID, VoucherDetail, oldValue);
            }
            else
            {
                _voucherDetailCache.TryAdd(VoucherDetail.VoucherDetailID, VoucherDetail);
            }
        }

        /// <summary>
        /// Delete Voucher Detail and Remove from Cache
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool Delete(VoucherDetail entity)
        {
            base.Delete(entity);

            _voucherDetailCache = MemoryCache.Default[CommonConstants.CONST_CACHE_VOUCHER_DETAIL] as ConcurrentDictionary<Guid, VoucherDetail>;

            if (_voucherDetailCache == null || _voucherDetailCache.Count == 0)
            {
                SetvoucherDetailCache();
            }

            if (_voucherDetailCache.ContainsKey(entity.VoucherDetailID))
            {
                VoucherDetail oldValue = null;
                _voucherDetailCache.TryRemove(entity.VoucherDetailID, out oldValue);
            }

            return true;
        }
    }
}
