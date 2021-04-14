using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.Middlewares
{
    public class TestMyMiddleware
    {
        RequestDelegate _next;

        /// <summary>
        /// 必要的构造函数，第一个参数必须是RequestDelegate
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public TestMyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 必须要有的方法
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("业务处理-请求");

            // 负责中间件的传递，如果这里不调用，就会形成断路
            await _next(context);

            Console.WriteLine("业务处理-响应");
        }
    }
}
