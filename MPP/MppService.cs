﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.MSProject;

namespace MPP2Todoist.MPP
{
    public class MppService
    {
        public static List<MppTask> LoadTasks(string mppFile)
        {
            var tasks = new List<MppTask>();

            var app = new Application();
            try
            {
                app.FileOpenEx(mppFile);

                var project = app.ActiveProject;

                foreach (Task task in project.Tasks.Cast<Task>().ToList())
                {
                    tasks.Add(new MppTask
                    {
                        Id = task.ID,
                        IndentLevel = task.OutlineLevel,
                        Ansvarlig = task.ResourceNames,
                        Name = String.Format("{0} - ansv.: {1}", task.Name, task.ResourceNames)
                    });
                }

                return tasks;
            }
            catch (System.Exception ex)
            {
                throw new MppServiceException("Error loading MS Project tasks", ex);
            }
            finally
            {
                app.FileCloseEx();
            }
        }
    }
}