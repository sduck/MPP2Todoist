using System.Collections.Generic;

namespace MPP2Todoist.Core.DataObjects
{
    public class MppTask : ITreeObject<MppTask>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Indent { get; set; }
        public string Ansvarlig { get; set; }
        public MppTask Parent { get; set; }
        public List<MppTask> Children { get; set; }

        public MppTask(int id, string name, int indent, string ansvarlig)
        {
            Id = id;
            Name = name;
            Indent = indent;
            Ansvarlig = ansvarlig;
            Children = new List<MppTask>();
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
