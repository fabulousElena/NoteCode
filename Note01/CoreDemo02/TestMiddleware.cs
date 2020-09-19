using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CoreDemo02
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;

        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //在这里写中间件的业务代码
            //next 前面是请求
            await _next(httpContext); //把响应报文上下文对象传递给下一个中间件。
            //next 后面是响应
        }
    }
}
