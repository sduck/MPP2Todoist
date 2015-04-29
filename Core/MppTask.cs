using System.Collections.Generic;

namespace MPP2Todoist
{
    public class MppTask
    {
        List<MppTask> _subtasks = new List<MppTask>();

        public int Id { get; set; }
        public string Name { get; set; }
        public short IndentLevel { get; set; }
        public string Ansvarlig { get; set; }
        public List<MppTask> Subtasks
        {
            get { return _subtasks; }
        }
    }
}
