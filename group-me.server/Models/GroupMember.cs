using System;
using group_me.server.Interfaces;

namespace group_me.server.Models
{
    public class GroupMemberDTO : IItem
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string AccountId { get; set; }
        public int GroupId { get; set; }
        public string Role { get; set; } = "member";
    }



    public class GroupMemberView : Account
    {
        public string AccountId { get; set; }
        public int GroupId { get; set; }
        public string Role { get; set; }
    }
}