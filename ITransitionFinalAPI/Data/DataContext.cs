using ITransitionFinalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ITransitionFinalAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionComments> CommentsInCollections { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<LikedCollection> LikedCollections { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserCollector> UserCollectors { get; set; }
        public DbSet<ItemCollection> ItemsCollections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollectionComments>()
                .HasKey(cc => new { cc.IdCollection, cc.IdComment });

            modelBuilder.Entity<CollectionComments>()
                .HasOne(cc => cc.Collection)
                .WithMany(c => c.Comments)
                .HasForeignKey(cc => cc.IdCollection)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CollectionComments>()
                .HasOne(cc => cc.Comment)
                .WithMany(c => c.CollectionComments)
                .HasForeignKey(cc => cc.IdComment)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LikedCollection>()
                .HasKey(lc => new { lc.IdCollection, lc.IdUserCollector });

            modelBuilder.Entity<LikedCollection>()
                .HasOne(lc => lc.Collection)
                .WithMany(c => c.LikedCollections)
                .HasForeignKey(lc => lc.IdCollection)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LikedCollection>()
                .HasOne(lc => lc.UserCollector)
                .WithMany(uc => uc.LikedCollections)
                .HasForeignKey(lc => lc.IdUserCollector)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemCollection>()
                .HasOne(ic => ic.Collection)
                .WithMany(c => c.ItemsCollection)
                .HasForeignKey(ic => ic.CollectionId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
