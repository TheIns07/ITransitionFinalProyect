namespace ITransitionFinalAPI.Models
{
    public class LikedCollection
    {
        public int IdCollection { get; set; }
        public int IdUserCollector { get; set; }
        public DateTime DateRegistred { get; set; }
        public Collection Collection { get; set; }
        public UserCollector UserCollector { get; set; }
    }
}
