using ImageViewer.Models;

namespace ImageViewer.Repositories
{
    public interface IImageRepository
    {
        Task<List<Image>> GetListAsync();
        Task<Image> GetAsync(Guid imageId);
        Task<Image> InsertAsync(Image image);
        Task<bool> UpdateAsync(Guid id, string name, string description);
        Task DeleteAsync(Guid imageId);
    }
}
