using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsDemo.Services
{
    public interface IComputerService
    {
        public void PowerON();

        public void ShutDown();
    }
}
