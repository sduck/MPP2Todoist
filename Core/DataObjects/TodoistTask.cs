using System.Collections.Generic;

namespace MPP2Todoist.Core.DataObjects
{
    public class TodoistTask : TaskBase<TodoistTask>
    {
        public TodoistTask(int id, string name, int indent)
        {
            Id = id;
            Name = name;
            Indent = indent;
            Children = new List<TodoistTask>();
        }
    }
}