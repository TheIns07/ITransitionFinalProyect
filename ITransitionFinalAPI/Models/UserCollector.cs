namespace ITransitionFinalAPI.Models
{
    public class UserCollector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTime DateSigned { get; set; }
        public List<Collection> Collections { get; set; } = new List<Collection>();
        public List<LikedCollection> LikedCollections { get; set; } = new List<LikedCollection>();
        public List<CollectionComments> Comments { get; set; } = new List<CollectionComments>();
    }
}
