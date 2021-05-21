using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace HerokuApplication.Web.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class)]
    public class SecretKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            AuthConfig config = new AuthConfig();
            context.HttpContext.RequestServices.GetRequiredService<IConfiguration>().Bind(nameof(AuthConfig), config);

            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
            {
                await next();
            }

            if (!context.HttpContext.Request.Headers.TryGetValue(config.Key, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key was not provided"
                };
                return;
            }

            if (!config.Value.Equals(extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key is not valid"
                };
                return;
            }

            await next();
        }

        protected class AuthConfig
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
}