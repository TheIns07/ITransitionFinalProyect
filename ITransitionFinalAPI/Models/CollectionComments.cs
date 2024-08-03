namespace ITransitionFinalAPI.Models
{
    public class CollectionComments
    {
        public int IdCollection { get; set; }
        public int IdCollectorUser { get; set; }
        public int IdComment { get; set; }

        public Collection Collection { get; set; }
        public UserCollector UserCollector { get; set; }
        public Comment Comment { get; set; }

    }
}
