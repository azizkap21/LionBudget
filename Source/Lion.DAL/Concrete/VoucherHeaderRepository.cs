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
    public class VoucherHeaderRepository:GenericRepository<VoucherHeader>, IVoucherHeaderRepository
    {
        private ConcurrentDictionary<Guid, VoucherHeader> _voucherHeaderCache;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VoucherHeader GetVoucherHeader(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.VoucherHeaderID == id);
        }

        public override IQueryable<VoucherHeader> GetAll()
        {
            GetVoucherHeaderCache();

            List<VoucherHeader> voucherHeaders = _voucherHeaderCache.Select(x => x.Value).ToList();

            return voucherHeaders.AsQueryable();
        }

        private void GetVoucherHeaderCache()
        {
            _voucherHeaderCache = MemoryCache.Default[CommonConstants.CONST_CACHE_VOUCHER_HEADER] as ConcurrentDictionary<Guid, VoucherHeader>;
            if (_voucherHeaderCache == null || _voucherHeaderCache.Count == 0)
            {
                SetVoucherHeaderCache();
            }
        }



        public void PreCacheEntity()
        {
            SetVoucherHeaderCache();
        }

        private void SetVoucherHeaderCache()
        {
            _voucherHeaderCache = new ConcurrentDictionary<Guid, VoucherHeader>();
            CacheItemPolicy policy = CachingHelper.GetCacheItemPolicy();

            List<VoucherHeader> voucherHeaders = dbSet.AsQueryable().ToList();

            foreach (VoucherHeader voucher in voucherHeaders)
            {
                _voucherHeaderCache.TryAdd(voucher.VoucherHeaderID, voucher);
            }

            MemoryCache.Default.Set(CommonConstants.CONST_CACHE_VOUCHER_HEADER, _voucherHeaderCache, policy);
   
        }



        /// <summary>
        /// Re Cache User on Update or New 
        /// </summary>
        /// <param name="userAccount"></param>
        public void ReCacheVoucherHeader(VoucherHeader voucherHeader)
        {
            GetVoucherHeaderCache();

            if (_voucherHeaderCache.ContainsKey(voucherHeader.VoucherHeaderID))
            {
                VoucherHeader oldValue = _voucherHeaderCache[voucherHeader.VoucherHeaderID];
                _voucherHeaderCache.TryUpdate(voucherHeader.VoucherHeaderID, voucherHeader, oldValue);
            }
            else
            {
                _voucherHeaderCache.TryAdd(voucherHeader.VoucherHeaderID, voucherHeader);
            }
        }

        /// <summary>
        /// Delete User Account and Remove from Cache
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool Delete(VoucherHeader entity)
        {
            base.Delete(entity);

            GetVoucherHeaderCache();

            if (_voucherHeaderCache.ContainsKey(entity.VoucherHeaderID))
            {
                VoucherHeader oldValue = null;
                _voucherHeaderCache.TryRemove(entity.VoucherHeaderID, out oldValue);
            }

            return true;
        }
    }
}
