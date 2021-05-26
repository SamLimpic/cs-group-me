using System;
using System.Collections.Generic;
using group_me.server.Models;
using group_me.server.Repositories;
using group_me.server.Interfaces;

namespace group_me.server.Services
{
    public class GroupsService : IService<Group>
    {
        private readonly GroupsRepository _repo;

        public GroupsService(GroupsRepository repo)
        {
            _repo = repo;
        }



        public List<Group> GetAll()
        {
            return _repo.GetAll();
        }



        public Group GetById(int id)
        {
            throw new NotImplementedException();
        }



        public Group Create(Group data)
        {
            throw new NotImplementedException();
        }



        public Group Update(Group data, string creatorId)
        {
            throw new NotImplementedException();
        }



        public void Delete(int id, string creatorId)
        {
            Group group = GetById(id);
            if (group.CreatorId != creatorId)
            {
                throw new Exception("You cannot delete another users Group");
            }
            if (!_repo.Delete(id))
            {
                throw new Exception("Something has gone wrong...");
            };
        }
    }
}