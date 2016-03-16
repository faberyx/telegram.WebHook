using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace telegram.webHook.Middleware
{
    public class RequestLogging
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLogging> _logger;

        public object File { get; private set; }

        public RequestLogging(RequestDelegate next, ILogger<RequestLogging> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var startTime = DateTime.UtcNow;

            var watch = Stopwatch.StartNew();
            await _next.Invoke(context);
            watch.Stop();
            try
            { 


                var logdata = $"Client IP: {context.Connection.RemoteIpAddress.ToString()} Request path: {context.Request.Path} Request content type: {context.Request.ContentType} Request content length: {context.Request.ContentLength} Start time: {startTime} Duration: { watch.ElapsedMilliseconds} " + Environment.NewLine;


                _logger.LogInformation(logdata);


         //       System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + DateTime.Now.ToString() + ".txt", logdata);
            }
            catch (Exception ex) {
                var a = ex.Message;
            }
        }
    }
}