using MediaRDemo.Colleague;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaRDemo.Mediator
{
    public abstract class HouseMediator
    {
        public abstract void SendHouseMsg(string msg, People people);
    }
}
