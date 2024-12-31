
namespace UniversityManagementSystem.UI.Middlewares
{
    /// <summary>
    /// Need For DI
    /// </summary>
    public class TestMiddleware:IMiddleware
    {
        public async Task InvokeAsync(HttpContext context,RequestDelegate next)
        {
            //Request handle logic
            await context.Response.WriteAsync("Processing the html request\n");
            await next(context);
            //Response handle logic
            await context.Response.WriteAsync("Processing the html response\n");
        }
    }
    /// <summary>
    /// Extension IApplicationBuilder for supporting the UseMiddleware function
    /// </summary>
    public static class TestMiddlewareExtension
    {
        public static IApplicationBuilder UseTestMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TestMiddleware>();
        }
    }

}
