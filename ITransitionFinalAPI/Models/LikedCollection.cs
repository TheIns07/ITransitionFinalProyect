namespace ITransitionFinalAPI.Models
{
    public class LikedCollection
    {
        public int Id { get; set; }
        public DateTime DateRegistred { get; set; }
        public int IdCollection { get; set; }
        public int IdUserCollector { get; set; }
        public Collection Collection { get; set; }
        public UserCollector UserCollector { get; set; }
    }
}
