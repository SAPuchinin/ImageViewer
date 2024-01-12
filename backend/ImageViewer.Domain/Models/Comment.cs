namespace ImageViewer.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; } = null!;
        public string Text { get; set; } = string.Empty;
        public double Left { get; set; }
        public double Top { get; set; }
        public DateTime CreationTime { get; set; }

        public Comment() { }
    }
}
