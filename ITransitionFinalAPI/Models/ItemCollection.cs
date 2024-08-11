namespace ITransitionFinalAPI.Models
{
    public class ItemCollection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateSigned { get; set; }
        public List<byte[]> Image { get; set; }
        public int CollectionId { get; set; }
        public Collection Collection { get; set; }
    }
}
