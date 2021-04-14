using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OptionsDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsDemo
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
            // 代码方式赋值
            //services.Configure<ComputerServiceOptions>(options =>
            //{
            //    options.Name = "New Computer";
            //    options.Cores = 2;
            //    options.IsSSD = true;
            //    options.MemorySize = 1024 * 10;
            //});

            // 初始化值来源于配置文件
            //services.Configure<ComputerServiceOptions>(Configuration.GetSection("ComputerConfig"));
            services.AddOptions<ComputerServiceOptions>().Configure(options =>
            {
                Configuration.GetSection("ComputerConfig").Bind(options);
            })
            .Validate(o => // 注册校验函数进行校验
            {
                return o.Name.Length <= 10;
            }, "Name长度不能大于10")
            .ValidateDataAnnotations() // 注解方式校验
            .Services.AddSingleton<IValidateOptions<ComputerServiceOptions>, ComputerServiceValidateOptions>();
            // 将服务注册到容器中
            services.AddScoped<IComputerService, ComputerService>();

            // 读取到配置后，在系统中进行加工
            services.PostConfigure<ComputerServiceOptions>(options =>
            {
                options.Name += "code 加工";
                options.Cores *= 2;
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
        }
    }
}
