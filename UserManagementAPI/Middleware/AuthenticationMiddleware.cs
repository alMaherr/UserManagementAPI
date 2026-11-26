namespace UserManagementAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ValidToken = "secret-token";

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(
                "Authorization",
                out var token))
            {
                context.Response.StatusCode = 401;

                await context.Response.WriteAsJsonAsync(new
                {
                    error = "Unauthorized"
                });

                return;
            }

            var bearerToken = token.ToString()
                .Replace("Bearer ", "");

            if (bearerToken != ValidToken)
            {
                context.Response.StatusCode = 401;

                await context.Response.WriteAsJsonAsync(new
                {
                    error = "Unauthorized"
                });

                return;
            }

            await _next(context);
        }
    }
}