using System;
using System.Reflection;

namespace AttributeLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintLogTest test = new PrintLogTest();
            test.Study();
            var type = test.GetType();
            var methods = type.GetMethods();
            foreach (var item in methods)
            {
                if (item.IsDefined(typeof(PrintLogAttribute), true))
                {
                    var attribute = item.GetCustomAttribute(typeof(PrintLogAttribute)) as PrintLogAttribute;
                    var msg = attribute.GetMsg();
                    Console.WriteLine($"得到标记信息：{msg}");
                }
            }
        }
    }
}
