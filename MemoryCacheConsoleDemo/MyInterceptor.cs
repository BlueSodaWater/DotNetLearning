using Castle.DynamicProxy;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryCacheConsoleDemo
{
    public class MyInterceptor : IInterceptor
    {
        private IMemoryCache memoryCache;

        public MyInterceptor(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public void Intercept(IInvocation invocation)
        {
            // 判断是否有自定义特性的MyCacheAttribute
            var attr = invocation.Method.GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(MyCacheAttribute));

            // 如果没有找到就不进行缓存
            if (attr == null)
            {
                invocation.Proceed();
            }
            // 找到就进行缓存
            else
            {
                // 取的参数值作为缓存Key
                string strKey = invocation.Arguments[0].ToString();
                // 获取值
                var value = this.memoryCache.Get(strKey);
                // 获取到就直接返回
                if (value != null)
                {
                    invocation.ReturnValue = "Intercept" + value;
                    return;
                }
                // 没获取到就执行拦截到的方法
                invocation.Proceed();
                // 将执行的结果进行缓存
                this.memoryCache.Set(strKey, invocation.ReturnValue);
            }
        }
    }
}
