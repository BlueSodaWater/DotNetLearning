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

            //// ʹ��Useע���м��
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello Use1\r\n");
            //    // �����󴫵ݵ���һ���м��
            //    await next();

            //    await context.Response.WriteAsync("Hello Use1 Response\r\n");
            //});

            //// ʹ��Useע���м�� �������Ͳ�һ��
            //app.Use(requestDelegate =>
            //{
            //    return async (context) =>
            //    {
            //        await context.Response.WriteAsync("Hello Use2\r\n");
            //        // �����󴫵ݵ���һ���м��
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

            //// ��֧�ܵ���ֻ��ƥ�䵽·�����߷�֧�ܵ�
            //app.Map("/Hello", builder =>
            //{
            //    builder.Use(async (context, next) =>
            //    {
            //        await context.Response.WriteAsync("Hello MapUse\r\n");
            //        await next();
            //        await context.Response.WriteAsync("Hello MapUse Response\r\n");
            //    });
            //    // ע���֧�ܵ��м��
            //    builder.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("Hello MapRun1~~~\r\n");
            //    });
            //    // ע���֧�ܵ��м��
            //    builder.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("Hello MapRun2~~~\r\n");
            //    });
            //});

            //// ʹ��Run
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello Run~~~\r\n");
            //});
            //// ʹ��Runע��
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello Test\r\n");
            //});
        }
    }
}
