using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRConsoleDemo
{
    public class MyRequestHandler : IRequestHandler<MyRequestMsg, int>
    {
        public Task<int> Handle(MyRequestMsg request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"开始处理消息了，消息类型为：{request.RequestMsgType}");
            return Task.FromResult(1);
        }
    }
}
