namespace ImageViewer.Models
{
    public class Image 
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string FileType { get; set; } = String.Empty;
        public DateTime UploadTime { get; set; }
        public byte[] Data { get; set; } = null!;

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public Image() { }
    }
}
