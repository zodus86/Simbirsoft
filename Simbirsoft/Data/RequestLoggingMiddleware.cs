using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbirsoft.Data
{
    /// <summary>
    /// 2.2.3 logger for Middleware
    /// </summary>
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public string Message { get; set; }

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            Message = $"Start {DateTime.Now}";
            try
            {
                await _next(context);
            }
            finally
            {
                Message += $"method - {context.Request?.Method}, finished - {DateTime.Now}";
            }
            _logger.LogInformation(Message);
        }
    }
}
