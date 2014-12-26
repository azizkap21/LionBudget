using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Collections.Concurrent;

namespace Lion.Core
{
   public  class CachingHelper
    {
       
       public static CacheItemPolicy GetCacheItemPolicy()
       {
           CacheItemPolicy policy = new CacheItemPolicy();

           policy.AbsoluteExpiration.AddHours(24);

           return policy;
       }
    }
}
