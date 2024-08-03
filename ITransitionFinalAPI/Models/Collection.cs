namespace ITransitionFinalAPI.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateSigned { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<CollectionComments> Comments { get; set; } = new List<CollectionComments>();
        public List<LikedCollection> LikedCollections { get; set; } = new List<LikedCollection>();

        // Custom Int Fields
        public int? CustomInt1 { get; set; }
        public int? CustomInt2 { get; set; }
        public int? CustomInt3 { get; set; }

        // Custom string Fields
        public string? CustomString1 { get; set; }
        public string? CustomString2 { get; set; }
        public string? CustomString3 { get; set; }

        // Custom multiline Fields
        public string? CustomMultilineText1 { get; set; }
        public string? CustomMultilineText2 { get; set; }
        public string? CustomMultilineText3 { get; set; }

        // Custom check Fields
        public bool? CustomBoolean1 { get; set; }
        public bool? CustomBoolean2 { get; set; }
        public bool? CustomBoolean3 { get; set; }

        //Custom date Fields 
        public DateTime? CustomDate1 { get; set; }
        public DateTime? CustomDate2 { get; set; }
        public DateTime? CustomDate3 { get; set; }

    }
}
