using System;
using System.Windows.Forms;
using MPP2Todoist.Core;

namespace MPP2Todoist.UI
{
    public partial class SyncForm : Form
    {
        public SyncForm()
        {
            InitializeComponent();

            foreach (var task in SyncService.Instance.GetNewTasks())
            {
                lstTasksToSync.Items.Add(task.FullName);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDoSync_Click(object sender, EventArgs e)
        {

        }
    }
}
