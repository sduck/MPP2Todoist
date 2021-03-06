﻿using System;
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

        #region Sync stuff

        private void EnableSync()
        {
            btnSync.Enabled = SyncService.Instance.ReadyForSync;
        }


        private void btnSync_Click(object sender, EventArgs e)
        {
            if (SyncService.Instance.ReadyForSync)
            {
                SyncService.Instance.MatchTasks();

                var syncForm = new SyncForm();
                syncForm.ShowDialog();

                LoadTodoistTasks();
            }
        }

        #endregion

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

            Properties.Settings.Default.MppFile = txtMppFile.Text;
            Properties.Settings.Default.Save();
        }

        private void btnLoadMppTasks_Click(object sender, EventArgs e)
        {
            var statusFilter = lstStatusFilter.CheckedItems.OfType<string>().ToList();
            var responsibleFilter = lstResponsibleFilter.CheckedItems.OfType<string>().ToList();
            SyncService.Instance.SetMppFilter(statusFilter, responsibleFilter);
            var tasks = SyncService.Instance.GetFilteredMppTasks();

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
            EnableSync();
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
            var savedProjectFilter = Properties.Settings.Default.TodoistProjectId;
            if (savedProjectFilter > 0)
            {
                foreach (var item in ddTodoistProjects.Items)
                {
                    var tmp = item as TodoistProject;
                    if (null != tmp && tmp.Id == savedProjectFilter)
                    {
                        ddTodoistProjects.SelectedItem = item;
                        break;
                    }
                }
            }
            else
            {
                ddTodoistProjects.SelectedIndex = 0;
            }

            ddTodoistProjects.Enabled = true;
            btnLoadTodoistTasks.Enabled = true;
        }

        private void btnLoadTodoistTasks_Click(object sender, EventArgs e)
        {
            LoadTodoistTasks();
        }

        private void LoadTodoistTasks()
        {
            var selectedProject = ddTodoistProjects.SelectedItem as TodoistProject;
            if (null != selectedProject)
            {
                var tasks = SyncService.Instance.GetTodoistTasks(selectedProject.Id);

                treeTodoistTasks.Nodes.Clear();
                FillTreeView(treeTodoistTasks.Nodes, tasks.Where(t => t.Parent == null).ToList());

                treeTodoistTasks.Enabled = true;
                treeTodoistTasks.ExpandAll();

                Properties.Settings.Default.TodoistProjectId = selectedProject.Id;
                Properties.Settings.Default.Save();
                EnableSync();
            }
        }

        #endregion

        private void FillTreeView<T>(TreeNodeCollection node, List<T> objectsToAdd) where T : ITreeObject<T>
        {
            foreach (var objectToAdd in objectsToAdd)
            {
                var newNode = new TreeNode(String.Format("{0}", objectToAdd))
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
    }
}
