namespace JiTU_CS.UI.Screens.Views
{
    partial class ClassesView
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("CSE325");
            this.lvwCourses = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Size = new System.Drawing.Size(751, 74);
            this.lblMessage.Text = "Select a Course";
            // 
            // lvwCourses
            // 
            this.lvwCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwCourses.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvwCourses.Location = new System.Drawing.Point(0, 74);
            this.lvwCourses.MultiSelect = false;
            this.lvwCourses.Name = "lvwCourses";
            this.lvwCourses.Size = new System.Drawing.Size(751, 420);
            this.lvwCourses.TabIndex = 2;
            this.lvwCourses.UseCompatibleStateImageBehavior = false;
            // 
            // ClassesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvwCourses);
            this.Name = "ClassesView";
            this.Size = new System.Drawing.Size(751, 494);
            this.Controls.SetChildIndex(this.lblMessage, 0);
            this.Controls.SetChildIndex(this.lvwCourses, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwCourses;



    }
}
