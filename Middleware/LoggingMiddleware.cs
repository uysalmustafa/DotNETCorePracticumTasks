namespace ProductsAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public LoggingMiddleware(ILoggerFactory logger_factory, RequestDelegate next)
        {
            _next = next;
            _logger = logger_factory.CreateLogger<LoggingMiddleware>();
        }
        public async Task Invoke(HttpContext context)
        { // Logging after accessing to action.
            try
            {
                await _next(context);
            }
            finally
            {
                _logger.LogInformation(
                    "Request {method} {url} => {statusCode}",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Response?.StatusCode);
            }
        }
    }
}
