using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryCacheConsoleDemo
{
    [Intercept(typeof(MyInterceptor))]
    public interface IUserService
    {
        string GetUser(string id);
        [MyCache]
        string GetUser1(string id);
    }
}
