namespace MPP2Todoist.UI
{
    partial class SyncForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDoSync = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.treeTasksToSync = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(298, 373);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDoSync
            // 
            this.btnDoSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoSync.Location = new System.Drawing.Point(191, 373);
            this.btnDoSync.Name = "btnDoSync";
            this.btnDoSync.Size = new System.Drawing.Size(101, 23);
            this.btnDoSync.TabIndex = 2;
            this.btnDoSync.Text = "Sync to Todoist";
            this.btnDoSync.UseVisualStyleBackColor = true;
            this.btnDoSync.Click += new System.EventHandler(this.btnDoSync_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tasks to create in Todoist";
            // 
            // treeTasksToSync
            // 
            this.treeTasksToSync.ImageIndex = 0;
            this.treeTasksToSync.ImageList = this.imageList;
            this.treeTasksToSync.Location = new System.Drawing.Point(15, 38);
            this.treeTasksToSync.Name = "treeTasksToSync";
            this.treeTasksToSync.SelectedImageIndex = 0;
            this.treeTasksToSync.Size = new System.Drawing.Size(358, 298);
            this.treeTasksToSync.TabIndex = 4;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "check_box.png");
            this.imageList.Images.SetKeyName(1, "check_box_uncheck.png");
            this.imageList.Images.SetKeyName(2, "add.png");
            this.imageList.Images.SetKeyName(3, "bullet_white.png");
            // 
            // SyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(385, 408);
            this.Controls.Add(this.treeTasksToSync);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDoSync);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SyncForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SyncForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDoSync;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeTasksToSync;
        private System.Windows.Forms.ImageList imageList;
    }
}