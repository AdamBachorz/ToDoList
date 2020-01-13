﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataAccess.Entity;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Model.DataAccess.Mappings
{
    public class ToDoItemMapping : ClassMapping<ToDoItem>
    {
        public ToDoItemMapping()
        {
            Table("TO_DO_ITEM");
            Id(x => x.Id, m => { m.Column("ID"); m.Generator(Generators.Native); });
            Property(x => x.Text, m => m.Column("TEXT"));
            Property(x => x.Checked, m => m.Column("CHECKED"));
            Property(x => x.RemindDate, m => m.Column("REMIND_DATE"));

            ManyToOne(x => x.ToDoList, map =>
            {
                map.Column("TO_DO_LIST_ID");
            });
        }
    }
}