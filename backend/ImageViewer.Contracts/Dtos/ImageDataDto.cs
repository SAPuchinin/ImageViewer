namespace ImageViewer.Dtos
{
    public class ImageDataDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double UploadTime { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Data { get; set; } = null!;
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}
