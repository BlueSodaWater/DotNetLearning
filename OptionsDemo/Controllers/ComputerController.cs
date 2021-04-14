using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptionsDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        [HttpGet("PowerOn")]
        public string PowerOn([FromServices] IComputerService computerService)
        {
            computerService.PowerON();
            return "开机成功！！！";
        }

        [HttpGet("ShutDown")]
        public string ShutDown([FromServices] IComputerService computerService)
        {
            computerService.ShutDown();
            return "关机完成！！！";
        }
    }
}
