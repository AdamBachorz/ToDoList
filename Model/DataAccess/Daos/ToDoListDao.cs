﻿using Model.DataAccess.Daos.Interfaces;
using Model.DataAccess.Entity;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccess.Daos
{
    public class ToDoListDao : BaseDao<ToDoList>, IToDoListDao 
    {
        public ToDoListDao() : base()
        {
            
        }

        public ToDoList GetOneByDate(DateTime? dateTime)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.CreateCriteria(typeof(ToDoList))
                    .Add(Restrictions.Eq("Date", dateTime))
                    .UniqueResult<ToDoList>();
            }
        }
        
        public IList<ToDoList> GetListsWithTaskMarkedToBeReminded()
        {
            throw new NotImplementedException();
        }
    }
}
