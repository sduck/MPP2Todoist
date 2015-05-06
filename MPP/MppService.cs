using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.MSProject;

namespace MPP2Todoist.MPP
{
    public class MppService
    {
        private List<TaskContainer> _tasks;
        private string _mppLoadedFile;

        public void LoadTasks(string mppFile)
        {
            var tasks = new List<TaskContainer>();
            var app = new Application();
            try
            {
                app.FileOpenEx(mppFile);

                var project = app.ActiveProject;

                tasks.AddRange(project.Tasks.Cast<Task>().ToList().Select(task => new TaskContainer
                {
                    Id = task.ID, IndentLevel = task.OutlineLevel, Responsible = task.ResourceNames, Name = task.Name, Status = task.Text1
                }));

                _tasks = tasks;
                _mppLoadedFile = mppFile;
            }
            catch (System.Exception ex)
            {
                throw new MppServiceException("Error loading MS Project tasks", ex);
            }
            finally
            {
                app.FileCloseEx();
                app.Quit();
                GC.Collect();
            }
        }

        public List<TaskContainer> GetTasks()
        {
            if (String.IsNullOrEmpty(_mppLoadedFile))
            {
                throw new MppServiceException("No MPP file loaded");
            }

            return _tasks;
        }

        public List<string> GetMppStatusList(string mppFile)
        {
            if (String.IsNullOrEmpty(_mppLoadedFile) || _tasks.Count == 0 || _mppLoadedFile != mppFile)
            {
                LoadTasks(mppFile);
            }

             return _tasks.GroupBy(t => t.Status).Select(g => g.Key).OrderBy(i => i).ToList();
        }

        public List<string> GetMppResponsibleList(string mppFile)
        {
            if (String.IsNullOrEmpty(_mppLoadedFile) || _tasks.Count == 0 || _mppLoadedFile != mppFile)
            {
                LoadTasks(mppFile);
            }

            return _tasks.GroupBy(t => t.Responsible).Select(g => g.Key).OrderBy(i => i).ToList();
        } 
    }
}
