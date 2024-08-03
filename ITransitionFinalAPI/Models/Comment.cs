namespace ITransitionFinalAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<CollectionComments> CollectionComments { get; set; } = new List<CollectionComments>();
    }
}
