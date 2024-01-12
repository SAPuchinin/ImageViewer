using ImageViewer.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ImageViewer.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ImageViewerContext _context;

        public CommentRepository(ImageViewerContext context)
        {
            _context = context;
        }

        public async Task DeleteAllCommentsFromImage(Guid id)
        {
            await _context.Comments.Where(c => c.ImageId == id).ExecuteDeleteAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _context.Comments.Where(c => c.Id == id).ExecuteDeleteAsync();
        }

        public async Task<Comment> InsertAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<bool> UpdateAsync(Guid id, string newText)
        {
            var c = await _context.Comments.Where(c => c.Id == id).
                ExecuteUpdateAsync(u =>
                    u.SetProperty(r => r.Text, newText)
                );

            return c > 0;
        }
    }
}
