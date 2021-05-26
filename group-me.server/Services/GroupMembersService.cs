using System;
using System.Collections.Generic;
using group_me.server.Models;
using group_me.server.Repositories;

namespace group_me.server.Services
{
    public class GroupMembersService
    {
        private readonly GroupMembersRepository _repo;

        public GroupMembersService(GroupMembersRepository repo)
        {
            _repo = repo;
        }

        internal List<GroupMemberView> GetAll(int groupId)
        {
            return _repo.GetAll(groupId);
        }

        internal GroupMemberDTO Create(GroupMemberDTO data)
        {
            return _repo.Create(data);
        }

        public void Delete(int groupId, string accountId)
        {
            // Get Group By Id
            // If(group.creatorId == accountId) => Good to Delete
            // Else throw new Exception "Bad!"
        }
    }
}