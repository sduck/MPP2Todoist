using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MPP2Todoist.Core;
using MPP2Todoist.Core.DataObjects;

namespace MPP2Todoist.UI
{
    public partial class SyncForm : Form
    {
        public SyncForm()
        {
            InitializeComponent();

            treeTasksToSync.Nodes.Clear();
            FillTreeView(treeTasksToSync.Nodes, SyncService.Instance.GetMatchedTasks().Where(t => t.Parent == null).ToList());

            treeTasksToSync.ExpandAll();
        }

        private void FillTreeView(TreeNodeCollection node, List<MppTask> objectsToAdd)
        {
            foreach (var objectToAdd in objectsToAdd)
            {
                var image = null != objectToAdd.Target ? 1 : 0;
                var newNode = new TreeNode(String.Format("{0}", objectToAdd), image, image)
                {
                    Tag = objectToAdd
                };

                node.Add(newNode);

                if (objectToAdd.Children.Count > 0)
                {
                    FillTreeView(newNode.Nodes, objectToAdd.Children);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDoSync_Click(object sender, EventArgs e)
        {
            SyncService.Instance.PushToTodoist();
            Close();
        }
    }
}
