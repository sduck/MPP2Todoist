using System.Collections.Generic;
using System.Linq;
using MPP2Todoist.Core.DataObjects;
using MPP2Todoist.MPP;
using MPP2Todoist.Todoist;

namespace MPP2Todoist.Core
{
    public sealed class SyncService
    {
        private readonly static SyncService _instance = new SyncService();
        private readonly MppService _mppService;
        private readonly User _todoistUser;
        private List<MppTask> _mppTasks;
        private List<TodoistTask> _todoistTasks;
        private List<string> _mppStatusFilter;
        private List<string> _mppResponsibleFilter;
 

        private SyncService()
        {
            _mppService = new MppService();
            _todoistUser = new User();
        }

        public static SyncService Instance
        {
            get { return _instance; }
        }

        #region Sync stuff

        public bool ReadyForSync
        {
            get
            {
                return (null != _mppTasks && _mppTasks.Count > 0) && (null != _todoistTasks && _todoistTasks.Count > 0);
            }
        }

        public void MatchTasks()
        {
            foreach (var mppTask in _mppTasks)
            {
                mppTask.MatchAgaistTarget(_todoistTasks);
            }
        }

        public List<MppTask> GetMatchedTasks()
        {
            return _mppTasks;
        } 

        #endregion

        #region MPP related

        public void SetMppFilter(List<string> statusFilter, List<string> responsibleFilter)
        {
            _mppStatusFilter = statusFilter;
            _mppResponsibleFilter = responsibleFilter;
        }
        public List<MppTask> GetFilteredMppTasks()
        {
            var tasks = _mppService.GetTasks().AsQueryable();

            if (null != _mppStatusFilter && _mppStatusFilter.Count > 0)
            {
                tasks = tasks.Where(t => _mppStatusFilter.Contains(t.Status));
            }

            if (null != _mppResponsibleFilter &&  _mppResponsibleFilter.Count > 0)
            {
                tasks = tasks.Where(t => _mppResponsibleFilter.Contains(t.Responsible));
            }

            var treeObjects = tasks.Select(t => new MppTask(t.Id, t.Name, t.IndentLevel, t.Responsible)).ToList();
            SetupTree(treeObjects);

            _mppTasks = treeObjects;
            return _mppTasks;
        }

        public void ReloadMppTasks(string mppFileName)
        {
            _mppService.LoadTasks(mppFileName);
        }

        public List<string> GetMppStatusList(string mppFileName)
        {
            return _mppService.GetMppStatusList(mppFileName);
        }

        public List<string> GetMppResponsibleList(string mppFileName)
        {
            return _mppService.GetMppResponsibleList(mppFileName);
        }

        #endregion

        #region Todoist related

        public void TodoistLogin(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return;
            }

            _todoistUser.LogOn(email, password);
        }

        public IEnumerable<TodoistProject> GetTodoistProjects()
        {
            return _todoistUser.GetProjects.Select(p => new TodoistProject(p.Id, p.Name, p.Indent));
        }

        public List<TodoistTask> GetTodoistTasks(int projectId)
        {
            var tasks = _todoistUser.GetUncompletedItemsByProjectId(projectId);

            var treeObjects = tasks.Select(task => new TodoistTask(task.Id, task.Content, task.Indent)).ToList();
            SetupTree(treeObjects);

            _todoistTasks = treeObjects;
            return _todoistTasks;
        }

        #endregion

        #region Tree helpers

        private void SetupTree<T>(List<T> treeObjects) where T : class, ITreeObject<T>
        {
            int parentLevel = 0;
            T currentParent = null;

            foreach (var treeObject in treeObjects)
            {
                if (treeObject.Indent > parentLevel)
                {
                    if (currentParent != null)
                    {
                        currentParent.Children.Add(treeObject);
                        treeObject.Parent = currentParent;
                    }

                    currentParent = treeObject;
                    parentLevel = treeObject.Indent;
                }
                else if (treeObject.Indent < parentLevel)
                {
                    // Outdent task
                    if (null != currentParent && null != currentParent.Parent)
                    {
                        var parent = currentParent.Parent;

                        for (var i = parentLevel - treeObject.Indent; i > 0; i--)
                        {
                            if (null != parent.Parent)
                            {
                                parent = parent.Parent;
                            }
                            else
                            {
                                parent = null;
                                break;
                            }
                        }

                        if (null != parent)
                        {
                            parent.Children.Add(treeObject);
                            treeObject.Parent = parent;
                        }
                    }

                    currentParent = treeObject;
                    parentLevel = treeObject.Indent;
                }
                else
                {
                    if (null != currentParent && null != currentParent.Parent)
                    {
                        currentParent.Parent.Children.Add(treeObject);
                        treeObject.Parent = currentParent.Parent;
                    }
                }
            }
        }

        #endregion
    }
}
