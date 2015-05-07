using System;
using System.Collections.Generic;
using System.Linq;

namespace MPP2Todoist.Core.DataObjects
{
    public abstract class TaskSyncSource<TSource, TTarget> : TaskBase<TSource> 
        where TSource : TaskBase<TSource>
        where TTarget : TaskBase<TTarget>
    {
        public TTarget Target { get; set; }

        public void MatchAgaistTarget(List<TTarget> targetList, int lastItemOrder)
        {
            var match = targetList.FirstOrDefault(t => t.FullName == FullName);

            if (null != match)
            {
                Target = match;
                ItemOrder = Math.Max(++lastItemOrder, match.ItemOrder);
            }
            else
            {
                // Assign new item order
                ItemOrder = ++lastItemOrder;
            }
        }
    }
}
