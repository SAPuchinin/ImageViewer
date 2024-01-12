using ImageViewer.Dtos;

namespace ImageViewer;

public class ImageViewerAppService :  IImageViewerAppService
{
    private readonly ImageManager _imageManager;

    public ImageViewerAppService(ImageManager imageManager)
    {
        _imageManager = imageManager;
    }

    public async Task<CommentDto> CreateCommentAsync(CreateCommentDto input)
    {
        var comment = await _imageManager.CreateCommentAsync(input.ImageId, input.Text, input.Left, input.Top);
        return ObjectMapper.ConvertToCommentDto(comment);
    }

    public async Task<ImageItemDto?> CreateImageAsync(CreateImageDto input)
    {
        if (input.File.Length > 0)
        {
            using (var stream = new MemoryStream())
            {
                if (String.IsNullOrEmpty(input.Name))
                    input.Name = input.File.FileName;

                input.File.CopyTo(stream);
                var bytes = stream.ToArray();
                var image = await _imageManager.CreateImageAsync(input.Name, input.Description, input.File.ContentType, bytes);

                return ObjectMapper.ConvertToItemDto(image);                
            }
        }
        return null;
    }

    public Task DeleteAllComments(Guid id)
    {
        return _imageManager.DeleteAllCommentsFromImage(id);
    }

    public Task DeleteCommentAsync(Guid id)
    {
        return _imageManager.DeleteComment(id);
    }

    public Task DeleteImageAsync(Guid id)
    {
        return _imageManager.DeleteImageAsync(id);
    }

    public async Task<ImageDataDto> GetImageAsync(Guid id)
    {
        var image = await _imageManager.GetImageAsync(id);
        return ObjectMapper.ConvertToDataDto(image);
    }

    public async Task<List<ImageItemDto>> GetImagesNameAsync()
    {
        var images = await _imageManager.GetImagesAsync();  
      
        return images.Select(i => ObjectMapper.ConvertToItemDto(i)).ToList();
    }

    public async Task<bool> UpdateCommentAsync(Guid id, UpdateCommentDto input)
    {
        return await _imageManager.UpdateCommentAsync(id, input.Text);
    }

    public async Task<bool> UpdateImageAsync(Guid id, UpdateImageDto input)
    {
        return await _imageManager.UpdateImageAsync(id, input.Name, input.Description);
    }
}
