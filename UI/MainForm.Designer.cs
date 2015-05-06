namespace MPP2Todoist.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtMppFile = new System.Windows.Forms.TextBox();
            this.btnLoadMpp = new System.Windows.Forms.Button();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.treeMppTasks = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoadMppTasks = new System.Windows.Forms.Button();
            this.lstStatusFilter = new System.Windows.Forms.CheckedListBox();
            this.lstResponsibleFilter = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLoadTodoistTasks = new System.Windows.Forms.Button();
            this.ddTodoistProjects = new System.Windows.Forms.ComboBox();
            this.treeTodoistTasks = new System.Windows.Forms.TreeView();
            this.btnTodoistLogin = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSync = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "MPP file:";
            // 
            // txtMppFile
            // 
            this.txtMppFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMppFile.Location = new System.Drawing.Point(61, 22);
            this.txtMppFile.Name = "txtMppFile";
            this.txtMppFile.Size = new System.Drawing.Size(334, 20);
            this.txtMppFile.TabIndex = 1;
            // 
            // btnLoadMpp
            // 
            this.btnLoadMpp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadMpp.Location = new System.Drawing.Point(401, 20);
            this.btnLoadMpp.Name = "btnLoadMpp";
            this.btnLoadMpp.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMpp.TabIndex = 2;
            this.btnLoadMpp.Text = "Open";
            this.btnLoadMpp.UseVisualStyleBackColor = true;
            this.btnLoadMpp.Click += new System.EventHandler(this.btnLoadMpp_Click);
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(76, 138);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(105, 20);
            this.txtCount.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Task count:";
            // 
            // treeMppTasks
            // 
            this.treeMppTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeMppTasks.Enabled = false;
            this.treeMppTasks.Location = new System.Drawing.Point(6, 167);
            this.treeMppTasks.Name = "treeMppTasks";
            this.treeMppTasks.Size = new System.Drawing.Size(470, 421);
            this.treeMppTasks.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnLoadMppTasks);
            this.groupBox1.Controls.Add(this.lstStatusFilter);
            this.groupBox1.Controls.Add(this.lstResponsibleFilter);
            this.groupBox1.Controls.Add(this.treeMppTasks);
            this.groupBox1.Controls.Add(this.btnLoadMpp);
            this.groupBox1.Controls.Add(this.txtCount);
            this.groupBox1.Controls.Add(this.txtMppFile);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 594);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MPP";
            // 
            // btnLoadMppTasks
            // 
            this.btnLoadMppTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadMppTasks.Enabled = false;
            this.btnLoadMppTasks.Location = new System.Drawing.Point(401, 138);
            this.btnLoadMppTasks.Name = "btnLoadMppTasks";
            this.btnLoadMppTasks.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMppTasks.TabIndex = 7;
            this.btnLoadMppTasks.Text = "Load tasks";
            this.btnLoadMppTasks.UseVisualStyleBackColor = true;
            this.btnLoadMppTasks.Click += new System.EventHandler(this.btnLoadMppTasks_Click);
            // 
            // lstStatusFilter
            // 
            this.lstStatusFilter.FormattingEnabled = true;
            this.lstStatusFilter.Location = new System.Drawing.Point(61, 48);
            this.lstStatusFilter.Name = "lstStatusFilter";
            this.lstStatusFilter.Size = new System.Drawing.Size(120, 79);
            this.lstStatusFilter.TabIndex = 6;
            // 
            // lstResponsibleFilter
            // 
            this.lstResponsibleFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResponsibleFilter.FormattingEnabled = true;
            this.lstResponsibleFilter.Location = new System.Drawing.Point(261, 48);
            this.lstResponsibleFilter.Name = "lstResponsibleFilter";
            this.lstResponsibleFilter.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstResponsibleFilter.Size = new System.Drawing.Size(215, 79);
            this.lstResponsibleFilter.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(187, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Responsible:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Status:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnLoadTodoistTasks);
            this.groupBox2.Controls.Add(this.ddTodoistProjects);
            this.groupBox2.Controls.Add(this.treeTodoistTasks);
            this.groupBox2.Controls.Add(this.btnTodoistLogin);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(501, 594);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Todoist";
            // 
            // btnLoadTodoistTasks
            // 
            this.btnLoadTodoistTasks.Enabled = false;
            this.btnLoadTodoistTasks.Location = new System.Drawing.Point(317, 77);
            this.btnLoadTodoistTasks.Name = "btnLoadTodoistTasks";
            this.btnLoadTodoistTasks.Size = new System.Drawing.Size(92, 23);
            this.btnLoadTodoistTasks.TabIndex = 5;
            this.btnLoadTodoistTasks.Text = "Load tasks";
            this.btnLoadTodoistTasks.UseVisualStyleBackColor = true;
            this.btnLoadTodoistTasks.Click += new System.EventHandler(this.btnLoadTodoistTasks_Click);
            // 
            // ddTodoistProjects
            // 
            this.ddTodoistProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddTodoistProjects.Enabled = false;
            this.ddTodoistProjects.FormattingEnabled = true;
            this.ddTodoistProjects.Location = new System.Drawing.Point(68, 79);
            this.ddTodoistProjects.Name = "ddTodoistProjects";
            this.ddTodoistProjects.Size = new System.Drawing.Size(227, 21);
            this.ddTodoistProjects.TabIndex = 4;
            // 
            // treeTodoistTasks
            // 
            this.treeTodoistTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeTodoistTasks.Enabled = false;
            this.treeTodoistTasks.Location = new System.Drawing.Point(6, 106);
            this.treeTodoistTasks.Name = "treeTodoistTasks";
            this.treeTodoistTasks.Size = new System.Drawing.Size(489, 482);
            this.treeTodoistTasks.TabIndex = 3;
            // 
            // btnTodoistLogin
            // 
            this.btnTodoistLogin.Location = new System.Drawing.Point(204, 48);
            this.btnTodoistLogin.Name = "btnTodoistLogin";
            this.btnTodoistLogin.Size = new System.Drawing.Size(91, 23);
            this.btnTodoistLogin.TabIndex = 2;
            this.btnTodoistLogin.Text = "Login";
            this.btnTodoistLogin.UseVisualStyleBackColor = true;
            this.btnTodoistLogin.Click += new System.EventHandler(this.btnTodoistLogin_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(68, 22);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(130, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(68, 50);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(130, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Project:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "E-mail:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(999, 600);
            this.splitContainer1.SplitterDistance = 488;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnSync
            // 
            this.btnSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSync.Enabled = false;
            this.btnSync.Location = new System.Drawing.Point(927, 626);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 23);
            this.btnSync.TabIndex = 1;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 661);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "MPP2Todoist";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMppFile;
        private System.Windows.Forms.Button btnLoadMpp;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeMppTasks;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnTodoistLogin;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeTodoistTasks;
        private System.Windows.Forms.Button btnLoadTodoistTasks;
        private System.Windows.Forms.ComboBox ddTodoistProjects;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLoadMppTasks;
        private System.Windows.Forms.CheckedListBox lstStatusFilter;
        private System.Windows.Forms.CheckedListBox lstResponsibleFilter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSync;
    }
}

