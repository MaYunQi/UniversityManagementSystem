namespace UniversityManagementSystem.UI.Middlewares
{
    /// <summary>
    /// No need for DI
    /// </summary>
    public class TestMiddleware2
    {
        private readonly RequestDelegate _next;
        public TestMiddleware2(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            //Request handle logic
            await context.Response.WriteAsync("Processing the html request\n");
            await _next(context);
            //Response handle logic
            await context.Response.WriteAsync("Processing the html response\n");
        }
    }
}
