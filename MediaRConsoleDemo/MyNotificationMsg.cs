using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 抽象通知消息，实现INotification
/// </summary>
namespace MediatRConsoleDemo
{
    public class MyNotificationMsg:INotification
    {
        public string MsgType { get; set; }
        public string MsgContent { get; set; }
    }
}
