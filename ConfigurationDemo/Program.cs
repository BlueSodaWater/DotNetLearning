using Microsoft.Extensions.Configuration;
using System;

namespace ConfigurationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddMyConfiguration();
            IConfiguration configuration = configurationBuilder.Build();

            Console.WriteLine($"TestTime:{configuration["TestTime"]}");
            Console.ReadLine();
        }
    }
}
