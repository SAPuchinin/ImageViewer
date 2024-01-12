using System;

namespace ImageViewer.Dtos
{
    public class CreateCommentDto
    {
        public Guid ImageId { get; set; }
        public string Text { get; set; } = string.Empty;
        public double Left { get; set; }
        public double Top { get; set; }
    }
}
