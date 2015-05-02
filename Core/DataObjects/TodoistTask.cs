using System.Collections.Generic;

namespace MPP2Todoist.Core.DataObjects
{
    public class TodoistTask : ITreeObject<TodoistTask>
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Indent { get; set; }
        public TodoistTask Parent { get; set; }
        public List<TodoistTask> Children { get; set; } 

        public TodoistTask(int id, string name, int indent)
        {
            Id = id;
            Name = name;
            Indent = indent;
            Children = new List<TodoistTask>();
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}