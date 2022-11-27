using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Dependency_Injection.Common.Filters
{
    public class ApiActionFilter : IActionFilter
    {
        private readonly ILogger<ApiActionFilter> _logger;

        public ApiActionFilter(ILogger<ApiActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionParams = JsonConvert.SerializeObject(context.ActionArguments);
            var path = context.HttpContext.Request.Path.ToString();
            var controllerName = context?.RouteData?.Values["controller"]?.ToString();
            var actionName = context?.RouteData?.Values["action"]?.ToString();


            var loggerMessage = "\nHttp Request Information:\n" + $"[DateTime]: {DateTime.UtcNow}\n" +
                                "[Life Status]: Start\n" + $"[Path]: {path}\n" + $"[Controller]:{controllerName}\n" +
                                $"[Action] :{actionName}\n" + $"[Action Parameters] : {actionParams} \n";

            _logger.LogDebug(loggerMessage);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var path = context.HttpContext.Request.Path.ToString();
            var response = "";

            if (context.Result != null && context.Result is ObjectResult)
            {
                var obj = (ObjectResult)context.Result;
                response = JsonConvert.SerializeObject(obj.Value);
            }

            var controllerName = context?.RouteData?.Values["controller"]?.ToString();
            var actionName = context?.RouteData?.Values["action"]?.ToString();


            var message = "\nHttp Response Information:\n" + $"[DateTime]: {DateTime.UtcNow}\n" +
                          "[Life Status]: End\n" + $"[Path]: {path}\n" + $"[Controller]:{controllerName}\n" +
                          $"[Action] :{actionName}\n" + $"[Response] : {response} \n";

            _logger.LogDebug(message);
        }
    }
}
