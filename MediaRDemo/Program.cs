using MediaRDemo.Colleague;
using MediaRDemo.Mediator;
using System;

namespace MediaRDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 先有个房屋中介公司
            AnJuKe anjuke = new AnJuKe();

            // 卖房者先找到房屋中介，发布房源信息，或获取卖房者购房意愿
            HouseSeller1 seller1 = new HouseSeller1(anjuke);
            HouseSeller2 seller2 = new HouseSeller2(anjuke);

            //买房者找到房屋中介，获取房源信息，或发布购房信息
            HouseBuyer1 buyer1 = new HouseBuyer1(anjuke);
            HouseBuyer2 buyer2 = new HouseBuyer2(anjuke);

            // 房屋中介进行登记
            anjuke.Seller1 = seller1;
            anjuke.Seller2 = seller2;
            anjuke.Buyer1 = buyer1;
            anjuke.Buyer2 = buyer2;

            seller1.SendMsg("sell1精品好房源");
            buyer1.SendMsg("buy1想要买房");
        }
    }
}
