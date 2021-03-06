using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatRConsoleDemo
{
    /// <summary>
    /// 实现IRquest抽象请求消息
    /// </summary>
    public class MyRequestMsg : IRequest<int>
    {
        /// <summary>
        /// 任意定义消息体，这里就定义了一个消息类型
        /// </summary>
        public string RequestMsgType { get; set; }
    }
}
