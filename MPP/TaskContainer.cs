using System.Collections.Generic;

namespace MPP2Todoist.MPP
{
    public class TaskContainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short IndentLevel { get; set; }
        public string Ansvarlig { get; set; }
    }
}
