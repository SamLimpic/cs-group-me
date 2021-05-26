using System;
using group_me.server.Interfaces;

namespace group_me.server.Models
{
    public class Group : IItem
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }

        public Account Creator { get; set; }
    }

}