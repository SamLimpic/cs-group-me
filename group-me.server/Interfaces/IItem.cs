using System;

namespace group_me.server.Interfaces
{
    public interface IItem
    {
        int Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}