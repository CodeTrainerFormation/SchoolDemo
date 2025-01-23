using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class MyFilter : Attribute, IExceptionFilter
    {
        [Inject]
        public ILogger<MyFilter> Logger { get; set; }

        public void OnException(ExceptionContext context)
        {
            //this.Logger.LogError("erreur");

            context.HttpContext.Response.WriteAsync("erreur detectée");
        }
    }
}
