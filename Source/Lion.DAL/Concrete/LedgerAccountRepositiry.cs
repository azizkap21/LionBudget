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
    public class LedgerAccountRepository:GenericRepository<LedgerAccount>,ILedgerAccountRepository
    {
        public LedgerAccount GetLedgerAccount(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.LedgerAccountID == id);
        }

        private ConcurrentDictionary<Guid, LedgerAccount> _ledgerAccountCache;

 
        public override IQueryable<LedgerAccount> GetAll()
        {
            GetLedgerAccountsFromCache();

            List<LedgerAccount> ledgerAccounts = _ledgerAccountCache.Select(x => x.Value).ToList();

            return ledgerAccounts.AsQueryable();
        }

        private void GetLedgerAccountsFromCache()
        {
            _ledgerAccountCache = MemoryCache.Default[CommonConstants.CONST_CACHE_LEDGER_ACCOUNT] as ConcurrentDictionary<Guid, LedgerAccount>;
            
            if (_ledgerAccountCache == null || _ledgerAccountCache.Count == 0)
            {
                SetLedgerAccountCache();
            }

        }



        public void PreCacheEntity()
        {
            SetLedgerAccountCache();
        }

        private void SetLedgerAccountCache()
        {
            _ledgerAccountCache = new ConcurrentDictionary<Guid, LedgerAccount>();
            CacheItemPolicy policy = CachingHelper.GetCacheItemPolicy();

            List<LedgerAccount> ledgerAccounts = dbSet.AsQueryable().ToList();

            foreach (LedgerAccount ledger in ledgerAccounts)
            {
                _ledgerAccountCache.TryAdd(ledger.LedgerAccountID, ledger);
            }

            MemoryCache.Default.Set(CommonConstants.CONST_CACHE_LEDGER_ACCOUNT, _ledgerAccountCache, policy);

        }

 

        /// <summary>
        /// Re Cache User on Update or New 
        /// </summary>
        /// <param name="userAccount"></param>
        public void ReCacheLedgerAccount(LedgerAccount ledgerAccount)
        {
            GetLedgerAccountsFromCache();

            if (_ledgerAccountCache.ContainsKey(ledgerAccount.LedgerAccountID))
            {
                LedgerAccount oldValue = _ledgerAccountCache[ledgerAccount.LedgerAccountID];
                _ledgerAccountCache.TryUpdate(ledgerAccount.LedgerAccountID, ledgerAccount, oldValue);
            }
            else
            {
                _ledgerAccountCache.TryAdd(ledgerAccount.LedgerAccountID, ledgerAccount);
            }

            
        }

        /// <summary>
        /// Delete User Account and Remove from Cache
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool Delete(LedgerAccount entity)
        {
            base.Delete(entity);

            GetLedgerAccountsFromCache();

            if (_ledgerAccountCache.ContainsKey(entity.LedgerAccountID))
            {
                LedgerAccount oldValue = null;
                _ledgerAccountCache.TryRemove(entity.LedgerAccountID, out oldValue);
            }

            return true;
        }

        public List<LedgerAccount> GetLedgerAccountsByUserId(Guid userId)
        {

            List<LedgerAccount> result = GetAll().Where(x => x.UserID == userId).ToList();

            return result;


        }
    }
}
