using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using TaskMasta.Models;

namespace TaskMasta.Repositories
{
    public class ListsRepository
    {
        private readonly IDbConnection _db;
        public ListsRepository(IDbConnection db)
        {
            _db = db;
        }

        public List<List> GetAllListsById(string id)
        {
            string sql = @"
                SELECT l.*,
                        a.*
                        FROM List l
                        JOIN  Accounts a ON l.creatorId = a.id
                        WHERE l.creatorId = @id;";
                        return _db.Query<List, Profile, List>(sql, (l,p) =>
                        {
                            l.CreatorId = p.Id;
                            return l;
                        }, new {id}).ToList();
        }

        public List CreateList(List listData)
        {
          var sql = @"
          INSERT INTO List(name, creatorId)
          VALUES (@ListName, @CreatorId);
          SELECT LAST_INSERT_ID();";
          var id = _db.ExecuteScalar<int>(sql, listData);
          listData.Id = id;
          return listData;
        }
    }
}