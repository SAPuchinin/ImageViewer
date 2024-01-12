namespace ImageViewer.Dtos
{
    public class CommentDto 
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public double CreationTime { get; set; }
        public double Left { get; set; }
        public double Top { get; set; }
    }
}
