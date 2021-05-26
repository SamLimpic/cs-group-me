namespace group_me.server.Models
{
    public class GroupMemberDTO
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public int GroupId { get; set; }
        public string Role { get; set; } = "member";
    }



    public class GroupMemberView : Profile
    {
        public string AccountId { get; set; }
        public int GroupId { get; set; }
        public string Role { get; set; }
    }
}