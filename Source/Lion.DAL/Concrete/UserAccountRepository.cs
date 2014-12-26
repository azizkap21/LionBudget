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
using System.Data.Entity;

namespace Lion.DAL.Concrete
{
    public class UserAccountRepository:GenericRepository<UserAccount>,IUserAccountRepository
    {
        private ConcurrentDictionary<Guid, UserAccount> _userAccountCache;

        public UserAccount GetUserAccount(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.UserAccountID == id);
        }

        public override IQueryable<UserAccount> GetAll()
        {
            _userAccountCache = MemoryCache.Default[CommonConstants.CONST_CACHE_USER_ACCOUNT] as ConcurrentDictionary<Guid, UserAccount>;
            if (_userAccountCache == null || _userAccountCache.Count == 0)
            {
                SetUserAccountCache();
            }

            List<UserAccount> userAccounts = _userAccountCache.Select(x => x.Value).ToList();

            return userAccounts.AsQueryable();
        }

        private void SetUserAccountCache()
        {
            _userAccountCache = new ConcurrentDictionary<Guid, UserAccount>();
            CacheItemPolicy policy = CachingHelper.GetCacheItemPolicy();

            List<UserAccount> userAccounts = dbSet.AsQueryable().ToList();

            foreach (UserAccount user in userAccounts)
            {
                _userAccountCache.TryAdd(user.UserAccountID, user);
            }

            MemoryCache.Default.Set(CommonConstants.CONST_CACHE_USER_ACCOUNT, _userAccountCache, policy);
        }

        public void PreCache()
        {
                SetUserAccountCache();

        }

        

        public void RecacheUser()
        {
            
        }
    }
}
