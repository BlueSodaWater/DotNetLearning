using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsDemo.Services
{
    public class ComputerServiceOptions
    {
        public string Name { get; set; } = "My Computer";

        public int Cores { get; set; } = 1;

        public int MemorySize { get; set; } = 512;

        public bool IsSSD { get; set; } = false;
    }
}
