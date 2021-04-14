using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MiddlewareDemo.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseTestMyMiddleware();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //// 使用Use注册中间件
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello Use1\r\n");
            //    // 将请求传递到下一个中间件
            //    await next();

            //    await context.Response.WriteAsync("Hello Use1 Response\r\n");
            //});

            //// 使用Use注册中间件 参数类型不一样
            //app.Use(requestDelegate =>
            //{
            //    return async (context) =>
            //    {
            //        await context.Response.WriteAsync("Hello Use2\r\n");
            //        // 将请求传递到下一个中间件
            //        await requestDelegate(context);

            //        await context.Response.WriteAsync("Hello Use2 Response\r\n");
            //    };
            //});

            //app.MapWhen(context =>
            //{
            //    return context.Request.Query.ContainsKey("TestMapWhen");
            //},builder=>
            //{
            //    builder.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("Hello MapWhenRun1~~~\r\n");
            //    });
            //});

            //// 分支管道，只有匹配到路径才走分支管道
            //app.Map("/Hello", builder =>
            //{
            //    builder.Use(async (context, next) =>
            //    {
            //        await context.Response.WriteAsync("Hello MapUse\r\n");
            //        await next();
            //        await context.Response.WriteAsync("Hello MapUse Response\r\n");
            //    });
            //    // 注册分支管道中间件
            //    builder.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("Hello MapRun1~~~\r\n");
            //    });
            //    // 注册分支管道中间件
            //    builder.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("Hello MapRun2~~~\r\n");
            //    });
            //});

            //// 使用Run
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello Run~~~\r\n");
            //});
            //// 使用Run注册
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello Test\r\n");
            //});
        }
    }
}
