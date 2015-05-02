using System.Collections.Generic;

namespace MPP2Todoist.Core.DataObjects
{
    public interface ITreeObject<T>
    {
        T Parent { get; set; }
        List<T> Children { get; set; }
        int Indent { get; set; }
    }
}