using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using TaskMasta.Models;

namespace TaskMasta.Repositories
{
    public class TasksRepository
    {
        private readonly IDbConnection _db;
        public TasksRepository(IDbConnection db)
        {
            _db = db;
        }
            public List<Task> GetAllTasksByListId(int id, string userId)
            {
                string sql = @"
                 SELECT * FROM Task WHERE ListId = @id AND creatorId = @userId;";
                 return _db.Query<Task>(sql).ToList();
            }
            public Task CreateTask(Task data)
            {
                var sql = @"
                INSERT INTO Task(name, Completed, CreatorId, ListId)
                VALUES (@Name, @Completed, @CreatorId, @ListId);
                SELECT LAST_INSERT_ID;";
                var id = _db.ExecuteScalar<int>(sql, data);
                data.Id = id;
                return data;
            }

        }
    }
