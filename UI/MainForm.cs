﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using MPP2Todoist.Core;
using MPP2Todoist.Core.DataObjects;
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

            FillTreeView(treeMppTasks.Nodes, tasks.Where(t => t.Parent == null).ToList());
            treeMppTasks.Enabled = true;
            treeMppTasks.ExpandAll();
        }

        private void RenderTree(List<TaskContainer> tasks)
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

                FillTreeView(treeTodoistTasks.Nodes, tasks.Where(t => t.Parent == null).ToList());

                treeTodoistTasks.Enabled = true;
                treeTodoistTasks.ExpandAll();

            }
        }

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
