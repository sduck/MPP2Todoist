using System;
using System.Collections.Generic;

namespace MPP2Todoist.Core.DataObjects
{
    public class TaskBase<T> : ITreeObject<T> where T : TaskBase<T>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Indent { get; set; }
        public int ItemOrder { get; set; }
        public T Parent { get; set; }
        public List<T> Children { get; set; }

        public string FullName
        {
            get
            {
                var fullname = Name;
                if (null != Parent)
                {
                    fullname = String.Format("{0}/{1}", Parent.FullName, fullname);
                }

                return fullname;
            }
        }


        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}