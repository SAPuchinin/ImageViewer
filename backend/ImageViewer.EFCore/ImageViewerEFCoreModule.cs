using ImageViewer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ImageViewer
{
    public static class ImageViewerEFCoreModule
    {
        public static void AddEFCore(this IServiceCollection services)
        {
            services.AddTransient<IImageRepository, ImageRepositoriy>();
            services.AddTransient<ICommentRepository, CommentRepository>();
        }
    }
}
