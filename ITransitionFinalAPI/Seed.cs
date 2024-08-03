using ITransitionFinalAPI.Data;
using ITransitionFinalAPI.Models;

namespace ITransitionFinalAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.CommentsInCollections.Any())
            {
                var tags = new List<Tag>
                {
                    new Tag { Name = "Art" },
                    new Tag { Name = "Science" },
                    new Tag { Name = "Technology" }
                };

                dataContext.Tags.AddRange(tags);
                dataContext.SaveChanges();

                var collections = new List<Collection>
                {
                    new Collection
                    {
                        Name = "Art Collection",
                        DateSigned = DateTime.UtcNow,
                        Tags = new List<Tag> { tags[0] }
                    },
                    new Collection
                    {
                        Name = "Science Collection",
                        DateSigned = DateTime.UtcNow,
                        Tags = new List<Tag> { tags[1] }
                    }
                };

                dataContext.Collections.AddRange(collections);
                dataContext.SaveChanges();

                var users = new List<UserCollector>
                {
                    new UserCollector
                    {
                        Name = "John Doe",
                        Role = "Collector",
                        DateSigned = DateTime.UtcNow
                    },
                    new UserCollector
                    {
                        Name = "Jane Smith",
                        Role = "Collector",
                        DateSigned = DateTime.UtcNow
                    }
                };

                dataContext.UserCollectors.AddRange(users);
                dataContext.SaveChanges();

                var comments = new List<Comment>
                {
                    new Comment
                    {
                        Title = "Great Collection",
                        Description = "I really enjoyed this collection.",
                        CreatedDate = DateTime.UtcNow
                    },
                    new Comment
                    {
                        Title = "Not Impressed",
                        Description = "I found this collection lacking.",
                        CreatedDate = DateTime.UtcNow
                    }
                };

                dataContext.Comments.AddRange(comments);
                dataContext.SaveChanges();

                var collectionComments = new List<CollectionComments>
                {
                    new CollectionComments
                    {
                        IdCollection = collections[0].Id,
                        IdComment = comments[0].Id,
                        IdCollectorUser = users[0].Id
                    },
                    new CollectionComments
                    {
                        IdCollection = collections[1].Id,
                        IdComment = comments[1].Id,
                        IdCollectorUser = users[1].Id
                    }
                };

                dataContext.CommentsInCollections.AddRange(collectionComments);
                dataContext.SaveChanges();

                var likedCollections = new List<LikedCollection>
                {
                    new LikedCollection
                    {
                        IdCollection = collections[0].Id,
                        IdUserCollector = users[1].Id,
                        DateRegistred = DateTime.UtcNow
                    },
                    new LikedCollection
                    {
                        IdCollection = collections[1].Id,
                        IdUserCollector = users[0].Id,
                        DateRegistred = DateTime.UtcNow
                    }
                };

                dataContext.LikedCollections.AddRange(likedCollections);
                dataContext.SaveChanges();
            }
        }
    }
}
