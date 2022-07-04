using Teleperformance.Bootcamp.WebApi.Middlewares;

namespace Teleperformance.Bootcamp.WebApi.Extension
{
    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
