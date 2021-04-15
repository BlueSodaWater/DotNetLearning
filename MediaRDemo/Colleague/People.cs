using MediaRDemo.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaRDemo.Colleague
{
    public abstract class People
    {
        // 和中介关联
        protected HouseMediator mediator;

        public People(HouseMediator mediator)
        {
            this.mediator = mediator;
        }

        public void SendMsg(string msg)
        {
            this.mediator.SendHouseMsg(msg, this);
        }
    }
}
