using System.Collections.Generic;
using System.Linq;

namespace MPP2Todoist.Core.DataObjects
{
    public abstract class TaskSyncSource<TSource, TTarget> : TaskBase<TSource> 
        where TSource : TaskBase<TSource>
        where TTarget : TaskBase<TTarget>
    {
        public int? TargetId { get; set; }

        public void MatchAgaistTarget(List<TTarget> targetList)
        {
            var match = targetList.FirstOrDefault(t => t.FullName == FullName);

            if (null != match)
            {
                TargetId = match.Id;
            }
        }
    }
}
