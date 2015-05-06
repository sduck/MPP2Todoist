using System.Collections.Generic;

namespace MPP2Todoist.Core.DataObjects
{
    public class MppTask : TaskSyncSource<MppTask, TodoistTask>
    {
        public string Ansvarlig { get; set; }

        public MppTask(int id, string name, int indent, string ansvarlig)
        {
            Id = id;
            Name = name;
            Indent = indent;
            Ansvarlig = ansvarlig;
            Children = new List<MppTask>();
        }
    }
}
