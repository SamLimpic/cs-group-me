namespace group_me.server.Models
{
    public class Group
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string CreatorId { get; set; }
        // public string CreatorName { get; set; }
        // public string CreatorImg { get; set; }

        public Profile Creator { get; set; }
    }
}