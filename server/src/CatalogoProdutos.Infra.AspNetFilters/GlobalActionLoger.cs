
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace CatalogoProdutos.Infra.AspNetFilters
{
    public class GlobalActionLoger : IActionFilter
    {

        private readonly ILogger<GlobalActionLoger> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;

        public GlobalActionLoger(ILogger<GlobalActionLoger> logger, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            

            if (_hostingEnvironment.IsDevelopment())
            {
                var data = new
                {
                    Version = "v1.0",
                    User = context.HttpContext.User.Identity.Name,
                    IP = context.HttpContext.Connection.RemoteIpAddress.ToString(),
                    Hostname = context.HttpContext.Request.Host.ToString(),
                    AreaAccessed = context.HttpContext.Request.GetDisplayUrl(),
                    Action = context.ActionDescriptor.DisplayName,
                    TimeStamp = DateTime.Now
                };

                _logger.LogInformation(1, data.ToString());
            }           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //throw new NotImplementedException();
        }


    }
}
