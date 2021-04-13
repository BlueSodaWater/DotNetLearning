using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeLearning
{
    /// <summary>
    /// 自定义日志打印
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class PrintLogAttribute : Attribute
    {
        private string userName;
        private string msg;
        public PrintLogAttribute(string userName, string msg)
        {
            this.userName = userName;
            this.msg = msg;
            Console.WriteLine($"{userName}于【{DateTime.Now.ToString("yyyy-MM-dd")}】{msg}");
        }
        public string GetMsg()
        {
            return $"{this.userName}于【{DateTime.Now.ToString("yyyy-MM-dd")}】{this.msg}";
        }
    }
}
