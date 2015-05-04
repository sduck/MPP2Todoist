using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.MSProject;

namespace MPP2Todoist.MPP
{
    public class MppService
    {
        private List<TaskContainer> _tasks;
        private string _mppFileLoaded;

        public void LoadTasks(string mppFile)
        {
            var tasks = new List<TaskContainer>();

            var app = new Application();
            try
            {
                app.FileOpenEx(mppFile);

                var project = app.ActiveProject;

                foreach (Task task in project.Tasks.Cast<Task>().ToList())
                {
                    tasks.Add(new TaskContainer
                    {
                        Id = task.ID,
                        IndentLevel = task.OutlineLevel,
                        Ansvarlig = task.ResourceNames,
                        Name = task.Name
                    });
                }

                _tasks = tasks;
                _mppFileLoaded = mppFile;
            }
            catch (System.Exception ex)
            {
                throw new MppServiceException("Error loading MS Project tasks", ex);
            }
            finally
            {
                app.FileCloseEx();
                app.Quit();
                app = null;
                GC.Collect();
            }
        }

        public List<TaskContainer> GetTasks(string mppFile)
        {
            if (String.IsNullOrEmpty(_mppFileLoaded) || _tasks.Count == 0 || _mppFileLoaded != mppFile)
            {
                LoadTasks(mppFile);
            }

            return _tasks;
        } 
    }
}
