using MediaRDemo.Colleague;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaRDemo.Mediator
{
    public class AnJuKe : HouseMediator
    {
        // 房屋中介需要知道所有人的具体信息
        private HouseBuyer1 buyer1;
        private HouseBuyer2 buyer2;
        private HouseSeller1 seller1;
        private HouseSeller2 seller2;

        public HouseBuyer1 Buyer1 { set => buyer1 = value; }
        public HouseBuyer2 Buyer2 { set => buyer2 = value; }
        public HouseSeller1 Seller1 { set => seller1 = value; }
        public HouseSeller2 Seller2 { set => seller2 = value; }

        // 通过发送消息
        public override void SendHouseMsg(string msg, People people)
        {
            // 如果是卖房者发出房源，模拟买房者收到信息
            if (people == seller1 || people == seller2)
            {
                buyer1.GetHouseMsg(msg);
                buyer2.GetHouseMsg(msg);
            }
            // 买房者发布购房信息，卖房者收到信息
            else
            {
                seller1.GetBuyHouseMsg(msg);
                seller2.GetBuyHouseMsg(msg);
            }
        }
    }
}
