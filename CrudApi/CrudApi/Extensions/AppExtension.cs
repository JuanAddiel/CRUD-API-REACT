using CrudApi.Middlewares;

namespace CrudApi.Extensions
{
    public static class AppExtension
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
