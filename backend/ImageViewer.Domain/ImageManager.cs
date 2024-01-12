using ImageViewer.Models;
using ImageViewer.Repositories;

namespace ImageViewer
{
    public class ImageManager
    {
        private readonly IImageRepository _imageRepository;
        private readonly ICommentRepository _commentRepository;

        public ImageManager(IImageRepository imageRepository, ICommentRepository commentRepository)
        {
            _imageRepository = imageRepository;
            _commentRepository = commentRepository;
        }

        public async Task<List<Image>> GetImagesAsync()
        {
            return await _imageRepository.GetListAsync();
        }

        public async Task<Image> GetImageAsync(Guid id)
        { 
            return await _imageRepository.GetAsync(id);
        }

        public async Task<Image> CreateImageAsync(string name, string description, string type, byte[] data)
        {
            var image = new Image()
            { 
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                FileType = type,
                UploadTime = DateTime.UtcNow,
                Data = data
            };

            return await _imageRepository.InsertAsync(image);
        }

        public async Task<bool> UpdateImageAsync(Guid id, string name, string description)
        {
            return await _imageRepository.UpdateAsync(id, name, description);
        }

        public Task DeleteImageAsync(Guid id)
        {
            return _imageRepository.DeleteAsync(id);
        }

        public Task DeleteAllCommentsFromImage(Guid id)
        {
            return _commentRepository.DeleteAllCommentsFromImage(id);
        }

        public Task DeleteComment(Guid id)
        {
            return _commentRepository.DeleteAsync(id);
        }

        public async Task<Comment> CreateCommentAsync(Guid imageId, string text, double left, double top)
        {
            var comment = new Comment()
            {
                Id = Guid.NewGuid(),
                ImageId = imageId,
                Text = text,
                Left = left,
                Top = top,
                CreationTime = DateTime.UtcNow
            };

            return await _commentRepository.InsertAsync(comment);
        }

        public async Task<bool> UpdateCommentAsync(Guid commentId, string newText)
        {
            return await _commentRepository.UpdateAsync(commentId, newText);
        }
    }
}
