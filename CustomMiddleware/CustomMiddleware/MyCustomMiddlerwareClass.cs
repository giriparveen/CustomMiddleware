using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddleware.CustomMiddleware
{
    
    public class MyCustomMiddlerwareClass
    {
        RequestDelegate _next;
        public MyCustomMiddlerwareClass(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("I am from custom middler ware");
            await _next.Invoke(context);
        }
    }

    public static class UseMyCustomMiddlewareClass
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder builder)
        {
          return  builder.UseMiddleware<MyCustomMiddlerwareClass>();
        }
    }
}
