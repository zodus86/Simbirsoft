using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Data
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var authorization = context.Request.Query["Basic"];

            //https://localhost:5001//Book/GetBooks?Basic=admin:admin
            if (authorization != "admin:admin")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("user or password is invalid");
            }
            else
            {
                await _next.Invoke(context);
            }

            await _next.Invoke(context);
        }
    }
}
