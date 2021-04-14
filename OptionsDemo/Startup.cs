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
            // ���뷽ʽ��ֵ
            //services.Configure<ComputerServiceOptions>(options =>
            //{
            //    options.Name = "New Computer";
            //    options.Cores = 2;
            //    options.IsSSD = true;
            //    options.MemorySize = 1024 * 10;
            //});

            // ��ʼ��ֵ��Դ�������ļ�
            //services.Configure<ComputerServiceOptions>(Configuration.GetSection("ComputerConfig"));
            services.AddOptions<ComputerServiceOptions>().Configure(options =>
            {
                Configuration.GetSection("ComputerConfig").Bind(options);
            })
            .Validate(o => // ע��У�麯������У��
            {
                return o.Name.Length <= 10;
            }, "Name���Ȳ��ܴ���10")
            .ValidateDataAnnotations() // ע�ⷽʽУ��
            .Services.AddSingleton<IValidateOptions<ComputerServiceOptions>, ComputerServiceValidateOptions>();
            // ������ע�ᵽ������
            services.AddScoped<IComputerService, ComputerService>();

            // ��ȡ�����ú���ϵͳ�н��мӹ�
            services.PostConfigure<ComputerServiceOptions>(options =>
            {
                options.Name += "code �ӹ�";
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
