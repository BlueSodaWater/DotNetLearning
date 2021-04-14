using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsDemo.Services
{
    public class ComputerServiceValidateOptions : IValidateOptions<ComputerServiceOptions>
    {
        public ValidateOptionsResult Validate(string name, ComputerServiceOptions options)
        {
            if (options.MemorySize <= 0)
            {
                return ValidateOptionsResult.Fail("内存不能小于或等于0");
            }
            else
            {
                return ValidateOptionsResult.Success;
            }
        }
    }
}
