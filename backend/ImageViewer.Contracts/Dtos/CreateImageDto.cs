using Microsoft.AspNetCore.Http;

namespace ImageViewer.Dtos
{
    public class CreateImageDto
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public IFormFile File { get; set; } = null!;
    }
}
