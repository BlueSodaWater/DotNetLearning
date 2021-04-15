using System;
using System.Reflection;

namespace AOPConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========原始需求=========");
            User user = new User { Name = "Zoe", Age = 18 };
            IUserService userService = new UserService();
            userService.AddUser(user);

            Console.WriteLine("========动态代理 实现新需求=========");
            IUserService userService1 = DispatchProxy.Create<IUserService, MyProxy>();
            ((MyProxy)userService1).TargetClass = new UserService();
            userService1.AddUser(user);
            Console.ReadLine();
        }
    }
}
