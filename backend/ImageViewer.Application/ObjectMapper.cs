using ImageViewer.Dtos;
using ImageViewer.Models;

namespace ImageViewer
{
    internal class ObjectMapper
    {
        public readonly static DateTime unixTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private static double ConvertToUnixTime(DateTime time)
        {
            return time.Subtract(unixTime).TotalMilliseconds;
        }

        public static ImageItemDto ConvertToItemDto(Image image)
        {
            return new ImageItemDto()
            {
                Id = image.Id,
                Name = image.Name,
                Description = image.Description,
                UploadTime = ConvertToUnixTime(image.UploadTime)
        };
        }

        public static ImageDataDto ConvertToDataDto(Image image)
        {
            return new ImageDataDto()
            {
                Id = image.Id,
                Name = image.Name,
                Description = image.Description,
                UploadTime = ConvertToUnixTime(image.UploadTime),
                Type = image.FileType,
                Data = Convert.ToBase64String(image.Data),
                Comments = image.Comments.Select(ConvertToCommentDto).ToList()
            };
        }

        public static CommentDto ConvertToCommentDto(Comment comment) 
        {
            return new CommentDto()
            {
                Id = comment.Id,
                CreationTime = ConvertToUnixTime(comment.CreationTime),
                Text = comment.Text,
                Left = comment.Left,
                Top = comment.Top
            };
        }

    }
}
