using System;
using System.Collections.Generic;
using TaskMasta.Models;
using TaskMasta.Repositories;

namespace TaskMasta.Services
{
    public class ListsService
    {
        private readonly ListsRepository _lr;

        public ListsService(ListsRepository lr)
        {
                    _lr = lr;
        }
        internal List<List> GetListsById(string id)
        {
            return _lr.GetAllListsById(id);
        }

        internal object CreateList(List listData)
        {
            var list = _lr.CreateList(listData);
            return list;
        }
    }
}