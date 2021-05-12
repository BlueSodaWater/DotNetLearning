using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

[assembly: HostingStartup(typeof(HostStartupLib.HostStartupLib))]
namespace HostStartupLib
{
    public class HostStartupLib : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            Debug.WriteLine("Lib程序中HostingStartupInLib类启动");

            // 添加配置
            builder.ConfigureAppConfiguration((context, config) =>
            {
                var datas = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("ServiceName", "HostStartupLib")
                };
                config.AddInMemoryCollection(datas);
            });

            // 添加ConfigureServices
            builder.ConfigureServices(services =>
            {
                services.AddScoped(provider => new Person { Id = 2, Name = "zwx", Age = 22 });
            });

            //添加Configure
            builder.Configure(app => {
                app.Use(async (context, next) =>
                {
                    await next();
                });
            });
        }
    }
}
