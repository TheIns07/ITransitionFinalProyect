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
                        Collection = collections[0],  
                        Comment = comments[0],        
                        UserCollector = users[0]      
                    },
                    new CollectionComments
                    {
                        Collection = collections[1], 
                        Comment = comments[1],       
                        UserCollector = users[1]      
                    }
                };

                        dataContext.CommentsInCollections.AddRange(collectionComments);
                        dataContext.SaveChanges();

                        var likedCollections = new List<LikedCollection>
                {
                    new LikedCollection
                    {
                        Collection = collections[0],  
                        UserCollector = users[1],      
                        DateRegistred = DateTime.UtcNow
                    },
                    new LikedCollection
                    {
                        Collection = collections[1],  
                        UserCollector = users[0],     
                        DateRegistred = DateTime.UtcNow
                    }
                };

                dataContext.LikedCollections.AddRange(likedCollections);
                dataContext.SaveChanges();
            }
        }
    }
}
