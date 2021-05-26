using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using group_me.server.Models;

namespace group_me.server.Repositories
{
    public class GroupMembersRepository
    {
        private readonly IDbConnection _db;

        public GroupMembersRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<GroupMemberView> GetAll(int groupId)
        {
            string sql = @"
            SELECT
            g.*
            a.*
            FROM groups g
            JOIN accounts a ON g.creatorId = a.Id;
            ";
            return _db.Query<GroupMemberView, Account, GroupMemberView>(sql, (g, a) =>
            {
                return g;
            }, splitOn: "id").ToList();
        }

        public GroupMemberDTO Create(GroupMemberDTO data)
        {
            string sql = @"
            INSERT INTO
            group_members(accountId, groupId)
            VALUES(@AccountId, @GroupId);
            SELECT LAST_INSERT_ID();
            ";
            data.Id = _db.ExecuteScalar<int>(sql, data);
            return data;
        }
    }
}