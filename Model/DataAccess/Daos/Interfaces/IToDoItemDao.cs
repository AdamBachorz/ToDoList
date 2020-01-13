﻿using Model.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccess.Daos.Interfaces
{
    public interface IToDoItemDao : IBaseDao<ToDoItem>
    {
        IList<ToDoItem> GetItemsByListId(int listId);
    }
}
