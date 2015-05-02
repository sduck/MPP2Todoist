using System;

namespace MPP2Todoist.Core.DataObjects
{
    public class TodoistProject
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int Indent { get; set; }

        public TodoistProject(int id, string name, int indent)
        {
            Id = id;
            Name = name;
            Indent = indent;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", new String(' ', (Indent - 1) * 3), Name);
        }
    }
}