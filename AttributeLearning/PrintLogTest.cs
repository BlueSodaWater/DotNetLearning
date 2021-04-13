using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeLearning
{
    public class PrintLogTest
    {
        [PrintLog("张三", "学习Attribute")]
        public void Study()
        {
            Console.WriteLine("张三在学习....");
        }

        [PrintLog("张三", "SayHello")]
        public string SayHello()
        {
            return "hello";
        }
    }
}
