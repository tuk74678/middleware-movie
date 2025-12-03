using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace MovieMiddleware.Filters;

public class LogFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Log.Information("Executing action {Action} at {Time}", 
            context.ActionDescriptor.DisplayName, DateTime.UtcNow);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Log.Information("Executed action {Action} at {Time}", 
            context.ActionDescriptor.DisplayName, DateTime.UtcNow);
    }
}