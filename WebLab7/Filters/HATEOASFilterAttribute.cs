using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using WebLab7.Models;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Routing;

namespace WebLab7.Filters
{
    public class HATEOASFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult && objectResult.Value != null)
            {
                var httpContext = context.HttpContext;
                var endpoint = httpContext.GetEndpoint();

                if (endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>() is ControllerActionDescriptor descriptor)
                {
                    // Get the current controller name
                    var controllerName = descriptor.ControllerName;

                    // Use reflection to find all actions in the controller
                    var controllerType = descriptor.ControllerTypeInfo;
                    var actions = controllerType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                        .Where(m => m.IsDefined(typeof(HttpMethodAttribute), true));

                    // Generate HATEOAS links dynamically
                    var links = actions.Select(action =>
                    {
                        // Get HTTP method attributes (e.g., [HttpGet], [HttpPost])
                        var httpMethods = action.GetCustomAttributes<HttpMethodAttribute>(true)
                            .SelectMany(attr => attr.HttpMethods)
                            .Distinct();

                        // Generate route URL
                        var routeTemplate = action.GetCustomAttributes<RouteAttribute>(true)
                            .FirstOrDefault()?.Template ?? string.Empty;

                        var url = $"/{controllerName}/{routeTemplate}".TrimEnd('/');

                        return httpMethods.Select(method =>
                            new Link(url, action.Name.ToLowerInvariant(), method.ToUpperInvariant()));
                    }).SelectMany(x => x).ToList();

                    // Wrap the original response in a Resource<T> and add links
                    var resourceType = typeof(Resource<>).MakeGenericType(objectResult.Value.GetType());
                    var resource = Activator.CreateInstance(resourceType, objectResult.Value);
                    resourceType.GetProperty("Links").SetValue(resource, links);

                    // Update the response
                    objectResult.Value = resource;
                }
            }

            base.OnResultExecuting(context);
        }
    }
}
