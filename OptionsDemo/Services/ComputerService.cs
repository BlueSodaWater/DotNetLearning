using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsDemo.Services
{
    public class ComputerService : IComputerService
    {
        private IOptions<ComputerServiceOptions> options;
        private IOptionsSnapshot<ComputerServiceOptions> optionsSnapshot;
        private IOptionsMonitor<ComputerServiceOptions> optionsMonitor;

        public ComputerService(IOptions<ComputerServiceOptions> options,
            IOptionsSnapshot<ComputerServiceOptions> optionsSnapshot,
            IOptionsMonitor<ComputerServiceOptions> optionsMonitor)
        {
            this.options = options;
            this.optionsSnapshot = optionsSnapshot;
            this.optionsMonitor = optionsMonitor;

            this.optionsMonitor.OnChange(options =>
            {
                Console.WriteLine("====================监听到改变了====================");
                Console.WriteLine($"电脑名称：{options.Name}");
            });
        }

        public void PowerON()
        {
            Console.WriteLine("====================开机中====================");
            Console.WriteLine($"电脑名称：{this.options.Value.Name}" +
                $"\r\n==OptionSnapshot-[{this.optionsSnapshot.Value.Name}]" +
                $"\r\n==OptionMonitor-[{this.optionsMonitor.CurrentValue.Name}]");
            Console.WriteLine($"电脑CPU核数：{this.options.Value.Cores}" +
                $"\r\n==OptionSnapshot-[{this.optionsSnapshot.Value.Cores}]" +
                $"\r\n==OptionMonitor-[{this.optionsMonitor.CurrentValue.Cores}]");
            Console.WriteLine($"电脑内存大小：{this.options.Value.MemorySize}" +
                $"\r\n==OptionSnapshot-[{this.optionsSnapshot.Value.MemorySize}]" +
                $"\r\n==OptionMonitor-[{this.optionsMonitor.CurrentValue.MemorySize}]");
            Console.WriteLine($"电脑硬盘是否是固态硬盘：{this.options.Value.IsSSD}" +
                $"\r\n==OptionSnapshot-[{this.optionsSnapshot.Value.IsSSD}]" +
                $"\r\n==OptionMonitor-[{this.optionsMonitor.CurrentValue.IsSSD}]");
            Console.WriteLine("====================已开机====================");
        }

        public void ShutDown()
        {
            Console.WriteLine("====================关机中====================");
            Console.WriteLine($"电脑名称：{this.options.Value.Name}");
            Console.WriteLine($"电脑CPU核数：{this.options.Value.Cores}");
            Console.WriteLine($"电脑内存大小：{this.options.Value.MemorySize}");
            Console.WriteLine($"电脑硬盘是否是固态硬盘：{this.options.Value.IsSSD}");
            Console.WriteLine("====================已关机====================");
        }
    }
}
