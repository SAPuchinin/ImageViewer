using ImageViewer.Models;

namespace ImageViewer.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment> InsertAsync(Comment comment);
        Task<bool> UpdateAsync(Guid id, string newText);
        Task DeleteAsync(Guid id);
        Task DeleteAllCommentsFromImage(Guid id);
    }
}
