using EmircanBlog_Service.Abstract;

namespace EmircanBlog_UI.Middlewares
{
    public class VisitorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public VisitorMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var visitorService = scope.ServiceProvider.GetRequiredService<IVisitorService>();
                await visitorService.IncrementVisitorCountServiceAsync();
            }

            await _next(context); // Sonraki middleware'i çağır
        }
    }

}
