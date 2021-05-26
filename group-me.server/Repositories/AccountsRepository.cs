using System.Data;
using cs_group_me_server.Models;
using Dapper;

namespace cs_group_me_server.Repositories
{
    public class AccountsRepository
    {
        private readonly IDbConnection _db;

        public AccountsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Account GetById(string Id)
        {
            string sql = "SELECT * FROM accounts WHERE id = @id";
            return _db.QueryFirstOrDefault<Account>(sql, new { Id });
        }

        internal Account Create(Account userInfo)
        {
            string sql = @"
            INSERT INTO accounts
            (id, name, picture, email)
            VALUES
            (@ID, @Name, @Picture, @Email)";
            _db.Execute(sql, userInfo);
            return userInfo;
        }
    }
}