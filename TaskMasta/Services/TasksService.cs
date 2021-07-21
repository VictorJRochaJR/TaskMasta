using System.Collections.Generic;
using TaskMasta.Models;
using TaskMasta.Repositories;

namespace TaskMasta.Services
{
    public class TasksService
    {
        private readonly TasksRepository _tr;
        public TasksService(TasksRepository tr)
        {
            _tr = tr;
        }

        internal List<Task> GetTasksByListId(int id, string userId)
        {
            return _tr.GetAllTasksByListId(id, userId);
        }

        internal Task CreateTask(Task taskData)
        {
            var task = _tr.CreateTask(taskData);
            return task;
        }
    }
    }
