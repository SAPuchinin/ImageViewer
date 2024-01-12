using Microsoft.Extensions.DependencyInjection;

namespace ImageViewer
{
    public static class ImageViewerApplicationModule
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IImageViewerAppService, ImageViewerAppService>();
        }
    }
}
