using System;
using System.Collections.Generic;

namespace MPP2Todoist.Core.DataObjects
{
    public class TodoistTask : TaskBase<TodoistTask>
    {
        public TodoistTask(int id, string name, int indent, int itemOrder)
        {
            Id = id;
            Name = name;
            Indent = indent;
            ItemOrder = itemOrder;
            Children = new List<TodoistTask>();
        }

        public override string ToString()
        {
            return String.Format("{0} : {1}", base.ToString(), ItemOrder);
        }
    }
}