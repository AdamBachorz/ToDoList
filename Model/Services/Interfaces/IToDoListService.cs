﻿using Model.DataAccess.Entity;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Interfaces
{
    public interface IToDoListService
    {
        IList<ToDoList> PopulateToDoListCache();
        void UpdateListCahce(int listId, ToDoItem toDoItem);
        ToDoItem DeleteItemFromListCahce(int listId, int toDoItemId);
        ToDoList PickNextToDoList(ToDoListModel currentList, bool forward);
    }
}