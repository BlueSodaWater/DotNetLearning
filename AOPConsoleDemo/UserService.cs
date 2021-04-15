using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPConsoleDemo
{
    public class UserService : IUserService
    {
        public bool AddUser(User user)
        {
            Console.WriteLine("用户添加成功");
            return true;
        }
    }
}
