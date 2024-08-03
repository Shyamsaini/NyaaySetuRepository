using NyaaySetu.Authentication;
using NyaaySetu.Data.Context;

namespace NyaaySetu.Infrastracture
{
    public static class ServiceBuilderExtension
    {
        public static void Dependencies(this IServiceCollection services)
        {
            services.AddSingleton<IJwtToken, JwtToken>();
            services.AddSingleton<DbContext>();
            
        }
    }
}
