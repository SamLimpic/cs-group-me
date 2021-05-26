using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using group_me.server.Models;
using group_me.server.Interfaces;

namespace group_me.server.Repositories
{
    public class GroupsRepository : IRepository<Group>
    {
        private readonly IDbConnection _db;

        public GroupsRepository(IDbConnection db)
        {
            _db = db;
        }



        public List<Group> GetAll()
        {
            string sql = @"
                SELECT
                g.*
                p.*
                FROM groups g
                JOIN profiles p ON g.creatorId = p.Id
                ";
            return _db.Query<Group, Account, Group>(sql, (group, account) =>
            {
                group.Creator = account;
                return group;
            }, splitOn: "id").ToList();
        }



        public Group GetById(int id)
        {
            string sql = @"
                SELECT 
                g.*,
                p.* 
                FROM groups g
                JOIN profiles p ON g.creatorId = p.id
                WHERE g.id = @id
                ";
            return _db.Query<Group, Account, Group>(sql, (group, profile) =>
            {
                group.Creator = profile;
                return group;
            }
            , new { id }, splitOn: "id").FirstOrDefault();
        }



        public Group Create(Group data)
        {
            string sql = @"
                INSERT INTO groups
                (creatorId, name, description, imgUrl)
                VALUES
                (@CreatorId, @Name, @Description, @ImgUrl)
                SELECT LAST_INSERT_ID()
                ";
            data.Id = _db.ExecuteScalar<int>(sql, data);
            return data;
        }



        public bool Update(Group data)
        {
            string sql = @"
            UPDATE groups
            SET
                name = @Name,
                description = @Description,
                imgUrl = @ImgUrl
            WHERE id = @id";
            int affectedRows = _db.Execute(sql, data);
            return affectedRows == 1;
        }



        public bool Delete(int id)
        {
            string sql = "DELETE FROM groups WHERE id = @id LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }

    }
}