using ImageViewer.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageViewer.Repositories
{
    public class ImageRepositoriy : IImageRepository
    {
        private readonly ImageViewerContext _context;

        public ImageRepositoriy(ImageViewerContext context) 
        {
            _context = context;
        }

        public async Task DeleteAsync(Guid imageId)
        {
            await _context.Images.Where(i => i.Id == imageId).ExecuteDeleteAsync();            
        }

        public async Task<Image?> GetAsync(Guid imageId)
        {
            return await _context.Images.Include(i => i.Comments).AsNoTracking().FirstOrDefaultAsync(i => i.Id == imageId);
        }

        public async Task<List<Image>> GetListAsync()
        {
            return (await _context.Images.Select(i => new {Id = i.Id, Name = i.Name, Description = i.Description, UploadTime = i.UploadTime })
                .ToListAsync())
                .Select(x => new Image() {Id = x.Id, Name = x.Name, Description = x.Description, UploadTime = x.UploadTime })
                .ToList();              
        }

        public async Task<Image> InsertAsync(Image image)
        {
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
            return image; 
        }

        public async Task<bool> UpdateAsync(Guid id, string name, string description)
        {
            var c = await _context.Images.Where(i => i.Id == id).
                ExecuteUpdateAsync(u =>                
                    u.SetProperty(r => r.Name, name)
                    .SetProperty(r => r.Description, description)
                );

            return c > 0;
        }
    }
}
