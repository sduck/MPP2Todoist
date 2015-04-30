using System.Collections.Generic;
using System.Net;
using MPP2Todoist.MPP;
using MPP2Todoist.Todoist;
using Todoist.NET;

namespace MPP2Todoist.Core
{
    public sealed class SyncService
    {
        private static SyncService _instance = new SyncService();
        private MppService _mppService;
        private User _todoistUser;

        private SyncService()
        {
            _mppService = new MppService();
            _todoistUser = new User();
        }

        public static SyncService Instance
        {
            get { return _instance; }
        }

        #region MPP related

        public List<MppTask> GetMppTasks(string mppFileName)
        {
            return _mppService.GetTasks(mppFileName);
        }

        public void ReloadMppTasks(string mppFileName)
        {
            _mppService.LoadTasks(mppFileName);
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

        public IEnumerable<Project> GetTodoistProjects()
        {
            return _todoistUser.GetProjects;
        }

        #endregion
    }
}
