using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using MPP2Todoist.Core;
using MPP2Todoist.Core.DataObjects;
using MPP2Todoist.Todoist;

namespace MPP2Todoist.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            txtMppFile.Text = Properties.Settings.Default.MppFile;
            txtEmail.Text = Properties.Settings.Default.TodoistEmail;
            txtPassword.Text = Properties.Settings.Default.TodoistPassword.DecryptString().ToInsecureString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MppFile = txtMppFile.Text;
            Properties.Settings.Default.Save();
        }

        #region MPP related

        private void btnLoadMpp_Click(object sender, EventArgs e)
        {
            var statusValues = SyncService.Instance.GetMppStatusList(txtMppFile.Text);
            var responsibles = SyncService.Instance.GetMppResponsibleList(txtMppFile.Text);
            var savedStatusFilter = Properties.Settings.Default.MppStatusFilter ?? new StringCollection();
            var savedResponsibleFilter = Properties.Settings.Default.MppResponsibleFilter ?? new StringCollection();

            foreach (var statusValue in statusValues)
            {
                lstStatusFilter.Items.Add(statusValue, savedStatusFilter.Contains(statusValue));
            }

            foreach (var responsible in responsibles)
            {
                lstResponsibleFilter.Items.Add(responsible, savedResponsibleFilter.Contains(responsible));
            }

            btnLoadMppTasks.Enabled = true;
        }

        private void btnLoadMppTasks_Click(object sender, EventArgs e)
        {
            var statusFilter = lstStatusFilter.CheckedItems.OfType<string>().ToList();
            var responsibleFilter = lstResponsibleFilter.CheckedItems.OfType<string>().ToList();
            var tasks = SyncService.Instance.GetMppTasks(txtMppFile.Text, statusFilter, responsibleFilter);

            var statusStore = new StringCollection();
            statusStore.AddRange(statusFilter.ToArray());
            Properties.Settings.Default.MppStatusFilter = statusStore;
            var responsibleStore = new StringCollection();
            responsibleStore.AddRange(responsibleFilter.ToArray());
            Properties.Settings.Default.MppResponsibleFilter = responsibleStore;
            Properties.Settings.Default.Save();

            txtCount.Text = tasks.Count.ToString();

            treeMppTasks.Nodes.Clear();
            FillTreeView(treeMppTasks.Nodes, tasks.Where(t => t.Parent == null).ToList());
            treeMppTasks.Enabled = true;
            treeMppTasks.ExpandAll();
        }

        #endregion

        #region Todoist related

        private void btnTodoistLogin_Click(object sender, EventArgs e)
        {

            try
            {
                SyncService.Instance.TodoistLogin(txtEmail.Text, txtPassword.Text);
                Properties.Settings.Default.TodoistEmail = txtEmail.Text;
                Properties.Settings.Default.TodoistPassword = txtPassword.Text.ToSecureString().EncryptString();
                Properties.Settings.Default.Save();
            }
            catch (WebException webException)
            {
                MessageBox.Show(webException.Message);
                return;
            }
            catch (LogOnFailedException loginFailedException)
            {
                MessageBox.Show(loginFailedException.Message);
                return;
            }

            var projects = SyncService.Instance.GetTodoistProjects();

            ddTodoistProjects.Items.Clear();
            foreach (var project in projects)
            {
                ddTodoistProjects.Items.Add(project);
            }

            ddTodoistProjects.Enabled = true;
            ddTodoistProjects.SelectedIndex = 0;
            btnLoadTodoistTasks.Enabled = true;
        }

        private void btnLoadTodoistTasks_Click(object sender, EventArgs e)
        {
            var selectedProject = ddTodoistProjects.SelectedItem as TodoistProject;
            if (null != selectedProject)
            {
                var tasks = SyncService.Instance.GetTodoistTasks(selectedProject.Id);

                treeTodoistTasks.Nodes.Clear();
                FillTreeView(treeTodoistTasks.Nodes, tasks.Where(t => t.Parent == null).ToList());

                treeTodoistTasks.Enabled = true;
                treeTodoistTasks.ExpandAll();

            }
        }


        #endregion

        private void FillTreeView<T>(TreeNodeCollection node, List<T> objectsToAdd) where T : ITreeObject<T>
        {
            foreach (var objectToAdd in objectsToAdd)
            {
                var newNode = new TreeNode(String.Format("{0}", objectToAdd));
                newNode.Tag = objectToAdd;
                node.Add(newNode);

                if (objectToAdd.Children.Count > 0)
                {
                    FillTreeView(newNode.Nodes, objectToAdd.Children);
                }
            }
        }
    }
}
