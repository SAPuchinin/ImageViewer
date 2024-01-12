using ImageViewer.Dtos;
using ImageViewer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageViewer.Controllers
{
    [Route("imageViewer")]
    public class ImageViewerController : Controller
    {
        private readonly IImageViewerAppService _imageViewerService;

        public ImageViewerController(IImageViewerAppService imageViewerService)
        {
            _imageViewerService = imageViewerService;
        }

        [HttpGet]
        [Route("images")]
        public Task<List<ImageItemDto>> GetImagesNameAsync()
        {
            return _imageViewerService.GetImagesNameAsync();
        }

        [HttpGet]
        [Route("images/{id}")]
        public Task<ImageDataDto> GetImageAsync(Guid id)
        {
            return _imageViewerService.GetImageAsync(id);
        }

        [HttpPost]
        [Route("images")]
        public Task<ImageItemDto> CreateImageAsync(CreateImageDto input)
        {
            return _imageViewerService.CreateImageAsync(input);
        }

        [HttpPut]
        [Route("images/{id}")]
        public Task<bool> UpdateImageAsync(Guid id, [FromBody]UpdateImageDto input)
        {
            return _imageViewerService.UpdateImageAsync(id, input);
        }

        [HttpDelete]
        [Route("images/{id}")]
        public Task DeleteImageAsync(Guid id)
        {
            return _imageViewerService.DeleteImageAsync(id);
        }

        [HttpDelete]
        [Route("images/{id}/comments")]
        public Task DeleteAllComments(Guid id)
        {
            return _imageViewerService.DeleteAllComments(id);  
        }

        [HttpPost]
        [Route("comments")]
        public Task<CommentDto> CreateCommentAsync([FromBody]CreateCommentDto input)
        {
            return _imageViewerService.CreateCommentAsync(input);
        }

        [HttpPut]
        [Route("comments/{id}")]
        public Task<bool> UpdateCommentAsync(Guid id, [FromBody]UpdateCommentDto input)
        {
            return _imageViewerService.UpdateCommentAsync(id, input);
        }

        [HttpDelete]
        [Route("comments/{id}")]
        public Task DeleteCommentAsync(Guid id)
        {
            return _imageViewerService.DeleteCommentAsync(id);
        }
    }
}
