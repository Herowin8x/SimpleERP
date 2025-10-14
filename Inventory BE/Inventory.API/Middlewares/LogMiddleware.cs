namespace MySample.Middlewares
{
    /// <summary>
    /// 
    /// </summary>
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _message;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="message"></param>
        public LogMiddleware(RequestDelegate next, string message)
        {
            _next = next;
            _message = message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            System.Diagnostics.Debug.WriteLine(_message, "Traceing: ");
            await _next(context);
        }
    }
}
