using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using MPP2Todoist.Core;
using MPP2Todoist.MPP;
using Todoist.NET;

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

        private void btnLoadMpp_Click(object sender, EventArgs e)
        {
            var tasks = SyncService.Instance.GetMppTasks(txtMppFile.Text);

            txtCount.Text = tasks.Count.ToString();

            RenderTree(tasks);
            treeMppTasks.Enabled = true;
        }

        private void RenderTree(List<MppTask> tasks)
        {
            treeMppTasks.Nodes.Clear();

            int parentLevel = 0;
            TreeNode currentParent = null;
            foreach (var task in tasks)
            {
                var node = new TreeNode(task.Name);
                if (task.IndentLevel > parentLevel)
                {
                    // Create subnode
                    if (currentParent == null)
                    {
                        // First node
                        treeMppTasks.Nodes.Add(node);
                    }
                    else
                    {
                        currentParent.Nodes.Add(node);
                    }

                    currentParent = node;
                    parentLevel = task.IndentLevel;
                }
                else if (task.IndentLevel < parentLevel)
                {
                    // Outdent task
                    if (currentParent.Parent.Parent == null)
                    {
                        treeMppTasks.Nodes.Add(node);
                    }
                    else
                    {
                        currentParent.Parent.Parent.Nodes.Add(node);
                    }

                    currentParent = node;
                    parentLevel = task.IndentLevel;
                }
                else
                {
                    currentParent.Parent.Nodes.Add(node);
                }
            }

            treeMppTasks.ExpandAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MppFile = txtMppFile.Text;
            Properties.Settings.Default.Save();
        }

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
                ddTodoistProjects.Items.Add(string.Concat(Enumerable.Repeat("   ", project.Indent - 1)) + project.Name);
            }

            ddTodoistProjects.Enabled = true;
            ddTodoistProjects.SelectedIndex = 0;
            btnLoadTodoistTasks.Enabled = true;
        }
    }
}
