using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryCacheConsoleDemo
{
    public class UserService : IUserService
    {
        private IMemoryCache memoryCache;

        public UserService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        // 代码嵌入到业务逻辑的缓存
        public string GetUser(string id)
        {
            var v = this.memoryCache.Get(id);
            if (v == null)
            {
                this.memoryCache.Set(id, id + ":Zoe");
                return id + ":Zoe";
            }
            else
            {
                return "Cache:" + v.ToString();
            }
        }

        public string GetUser1(string id)
        {
            return id + ":Zoe1";
        }
    }
}
