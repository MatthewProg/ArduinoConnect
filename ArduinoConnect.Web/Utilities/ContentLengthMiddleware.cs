using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArduinoConnect.Web.Utilities
{
    public class ContentLengthMiddleware
    {
        RequestDelegate _next;

        public ContentLengthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var originalBody = context.Response.Body;
            var ms = new MemoryStream();
            context.Response.Body = ms;
            long length = 0;
            context.Response.OnStarting((state) =>
            {
                context.Response.Headers.ContentLength = length;
                return Task.FromResult(0);
            }, context);
            await _next(context);
            length = context.Response.Body.Length;
            context.Response.Body.Position = 0;
            await ms.CopyToAsync(originalBody);
        }
    }
}
