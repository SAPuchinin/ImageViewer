using ImageViewer.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageViewer
{
    public class ImageViewerContext : DbContext

    {

        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ImageViewerContext(DbContextOptions<ImageViewerContext> options) : base(options) 
        { 
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>(obj =>
            {
                obj.HasOne(c => c.Image).WithMany(i => i.Comments).HasForeignKey(c => c.ImageId).OnDelete(DeleteBehavior.ClientCascade);
            });

        }
    }
}