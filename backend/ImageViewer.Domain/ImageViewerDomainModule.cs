using Microsoft.Extensions.DependencyInjection;

namespace ImageViewer
{
    public static class DomainModule
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddTransient<ImageManager>();            
        }
    }
}
