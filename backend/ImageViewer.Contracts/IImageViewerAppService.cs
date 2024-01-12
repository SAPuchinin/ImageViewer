using ImageViewer.Dtos;
using Microsoft.AspNetCore.Http;

namespace ImageViewer
{
    public interface IImageViewerAppService
    {
        Task<List<ImageItemDto>> GetImagesNameAsync();
        Task<ImageDataDto> GetImageAsync(Guid id);
        Task<ImageItemDto?> CreateImageAsync(CreateImageDto input);
        Task<bool> UpdateImageAsync(Guid id, UpdateImageDto input);
        Task DeleteImageAsync(Guid id);
        Task DeleteAllComments(Guid id);
        Task<CommentDto> CreateCommentAsync(CreateCommentDto input);
        Task<bool> UpdateCommentAsync(Guid id, UpdateCommentDto input);
        Task DeleteCommentAsync(Guid id);
    }
}
