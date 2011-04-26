namespace JiTU_CS.UI.Screens.Views
{
    partial class QuizzesView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Quiz 1", 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizzesView));
            this.lvwQuizzes = new System.Windows.Forms.ListView();
            this.imlquizzes = new System.Windows.Forms.ImageList(this.components);
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.submitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Text = "Quizzes";
            // 
            // lvwQuizzes
            // 
            this.lvwQuizzes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwQuizzes.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lvwQuizzes.LargeImageList = this.imlquizzes;
            this.lvwQuizzes.Location = new System.Drawing.Point(0, 95);
            this.lvwQuizzes.Name = "lvwQuizzes";
            this.lvwQuizzes.Size = new System.Drawing.Size(674, 467);
            this.lvwQuizzes.TabIndex = 2;
            this.lvwQuizzes.UseCompatibleStateImageBehavior = false;
            // 
            // imlquizzes
            // 
            this.imlquizzes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlquizzes.ImageStream")));
            this.imlquizzes.TransparentColor = System.Drawing.Color.Transparent;
            this.imlquizzes.Images.SetKeyName(0, "quiz.gif");
            // 
            // mnsMain
            // 
            this.mnsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.editToolStripMenuItem,
            this.submitToolStripMenuItem});
            this.mnsMain.Location = new System.Drawing.Point(0, 55);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(674, 40);
            this.mnsMain.TabIndex = 3;
            this.mnsMain.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::JiTU_CS.Properties.Resources.add;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(44, 36);
            this.addToolStripMenuItem.ToolTipText = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::JiTU_CS.Properties.Resources.remove;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(44, 36);
            this.removeToolStripMenuItem.ToolTipText = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::JiTU_CS.Properties.Resources.edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(44, 36);
            this.editToolStripMenuItem.ToolTipText = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // submitToolStripMenuItem
            // 
            this.submitToolStripMenuItem.Image = global::JiTU_CS.Properties.Resources.accept;
            this.submitToolStripMenuItem.Name = "submitToolStripMenuItem";
            this.submitToolStripMenuItem.Size = new System.Drawing.Size(44, 36);
            this.submitToolStripMenuItem.ToolTipText = "Submit";
            this.submitToolStripMenuItem.Click += new System.EventHandler(this.submitToolStripMenuItem_Click);
            // 
            // QuizzesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvwQuizzes);
            this.Controls.Add(this.mnsMain);
            this.Name = "QuizzesView";
            this.Controls.SetChildIndex(this.lblMessage, 0);
            this.Controls.SetChildIndex(this.mnsMain, 0);
            this.Controls.SetChildIndex(this.lvwQuizzes, 0);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwQuizzes;
        private System.Windows.Forms.ImageList imlquizzes;
        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem submitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}
