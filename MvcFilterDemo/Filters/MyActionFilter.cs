using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFilterDemo.Filters
{
    public class MyActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // context.RouteData 获取路由信息
            Console.WriteLine("OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // context.RouteData 获取路由相关信息
            // context.HttpContext 拿到HttpContext 无所不能
            if (!context.ModelState.IsValid) // 如果是模型绑定，可以判断参数是否合法
            {
                Console.WriteLine("OnActionExecuting参数不合法");
            }
            Console.WriteLine("OnActionExecuting方法执行");
        }
    }
}
