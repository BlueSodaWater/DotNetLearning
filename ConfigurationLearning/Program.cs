using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ConfigurationLearning
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            await host.RunAsync();
        }

        // Json
        //static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureAppConfiguration((hostingContext, configuration) =>
        //        {
        //            configuration.Sources.Clear();

        //            IHostEnvironment env = hostingContext.HostingEnvironment;

        //            var path = AppDomain.CurrentDomain.BaseDirectory;
        //            string projectDirectory = Directory.GetParent(path).Parent.Parent.Parent.FullName;
        //            configuration
        //                .AddJsonFile($"{projectDirectory}//appsettings.json", optional: true, reloadOnChange: true)
        //                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

        //            IConfigurationRoot configurationRoot = configuration.Build();

        //            TransientFaultHandlingOptions options = new();
        //            configurationRoot.GetSection(nameof(TransientFaultHandlingOptions))
        //                .Bind(options);

        //            Console.WriteLine($"TransientFaultHandlingOptions.Enabled={options.Enabled}");
        //            Console.WriteLine($"TransientFaultHandlingOptions.AutoRetryDelay={options.AutoRetryDelay}");
        //        });

        // xml
        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();

                    var path = AppDomain.CurrentDomain.BaseDirectory;
                    string projectDirectory = Directory.GetParent(path).Parent.Parent.Parent.FullName;
                    configuration
                        .AddXmlFile($"{projectDirectory}//appsettings.xml", optional: true, reloadOnChange: true)
                        .AddXmlFile($"repeating-example.xml", true, true);

                    configuration.AddEnvironmentVariables();

                    if (args is { Length: > 0 })
                    {
                        configuration.AddCommandLine(args);
                    }
                });
    }
}
