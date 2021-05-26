using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using group_me.server.Models;

namespace group_me.server.Repositories
{
    public class GroupsRepository
    {
        private readonly IDbConnection _db;

        public GroupsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Group> GetAll()
        {
            string sql = @"
            SELECT
            g.*
            a.*
            FROM groups g
            JOIN profiles p ON g.creatorId = p.Id;
            ";
            return _db.Query<Group, Profile, Group>(sql, (g, p) =>
            {
                g.Creator = p;
                return g;
            }, splitOn: "id").ToList();
        }
    }
}