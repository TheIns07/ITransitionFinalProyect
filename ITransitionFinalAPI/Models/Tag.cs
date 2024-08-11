namespace ITransitionFinalAPI.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Collection> Collections { get; set; } = new List<Collection>();
    }
}
