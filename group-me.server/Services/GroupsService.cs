using System;
using System.Collections.Generic;
using group_me.server.Models;
using group_me.server.Repositories;

namespace group_me.server.Services
{
    public class GroupsService
    {
        private readonly GroupsRepository _repo;

        public GroupsService(GroupsRepository repo)
        {
            _repo = repo;
        }

        internal List<Group> GetAll()
        {
            return _repo.GetAll();
        }
    }
}