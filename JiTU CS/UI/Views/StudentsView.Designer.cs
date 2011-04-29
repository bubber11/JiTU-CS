namespace JiTU_CS.UI.Views
{
    partial class StudentsView
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Student A");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Student B");
            this.lvwStudentsInCourse = new System.Windows.Forms.ListView();
            this.lvwAllStudents = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Size = new System.Drawing.Size(675, 74);
            this.lblMessage.Text = "Students";
            // 
            // lvwStudentsInCourse
            // 
            this.lvwStudentsInCourse.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvwStudentsInCourse.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvwStudentsInCourse.Location = new System.Drawing.Point(0, 74);
            this.lvwStudentsInCourse.Name = "lvwStudentsInCourse";
            this.lvwStudentsInCourse.Size = new System.Drawing.Size(283, 488);
            this.lvwStudentsInCourse.TabIndex = 2;
            this.lvwStudentsInCourse.UseCompatibleStateImageBehavior = false;
            this.lvwStudentsInCourse.View = System.Windows.Forms.View.List;
            // 
            // lvwAllStudents
            // 
            this.lvwAllStudents.Dock = System.Windows.Forms.DockStyle.Right;
            this.lvwAllStudents.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lvwAllStudents.Location = new System.Drawing.Point(360, 74);
            this.lvwAllStudents.Name = "lvwAllStudents";
            this.lvwAllStudents.Size = new System.Drawing.Size(315, 488);
            this.lvwAllStudents.TabIndex = 3;
            this.lvwAllStudents.UseCompatibleStateImageBehavior = false;
            this.lvwAllStudents.View = System.Windows.Forms.View.List;
            // 
            // StudentsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvwAllStudents);
            this.Controls.Add(this.lvwStudentsInCourse);
            this.Name = "StudentsView";
            this.Size = new System.Drawing.Size(675, 562);
            this.Controls.SetChildIndex(this.lblMessage, 0);
            this.Controls.SetChildIndex(this.lvwStudentsInCourse, 0);
            this.Controls.SetChildIndex(this.lvwAllStudents, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwStudentsInCourse;
        private System.Windows.Forms.ListView lvwAllStudents;
    }
}
