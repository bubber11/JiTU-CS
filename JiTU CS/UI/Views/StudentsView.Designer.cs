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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentsView));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Student A", "student.png");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Student B");
            this.imlMain = new System.Windows.Forms.ImageList(this.components);
            this.gbCourse = new System.Windows.Forms.GroupBox();
            this.lvwStudentsInCourse = new System.Windows.Forms.ListView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.gbAll = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwStudentsNotInCourse = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCourse.SuspendLayout();
            this.gbAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Size = new System.Drawing.Size(737, 50);
            this.lblMessage.Text = "Manage Students";
            // 
            // imlMain
            // 
            this.imlMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMain.ImageStream")));
            this.imlMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imlMain.Images.SetKeyName(0, "student.png");
            // 
            // gbCourse
            // 
            this.gbCourse.Controls.Add(this.lvwStudentsInCourse);
            this.gbCourse.Controls.Add(this.btnRemove);
            this.gbCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCourse.Location = new System.Drawing.Point(0, 63);
            this.gbCourse.Name = "gbCourse";
            this.gbCourse.Padding = new System.Windows.Forms.Padding(10);
            this.gbCourse.Size = new System.Drawing.Size(482, 501);
            this.gbCourse.TabIndex = 4;
            this.gbCourse.TabStop = false;
            this.gbCourse.Text = "Students currently enrolled";
            // 
            // lvwStudentsInCourse
            // 
            this.lvwStudentsInCourse.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvwStudentsInCourse.HideSelection = false;
            this.lvwStudentsInCourse.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvwStudentsInCourse.LargeImageList = this.imlMain;
            this.lvwStudentsInCourse.Location = new System.Drawing.Point(10, 23);
            this.lvwStudentsInCourse.Name = "lvwStudentsInCourse";
            this.lvwStudentsInCourse.Size = new System.Drawing.Size(462, 419);
            this.lvwStudentsInCourse.TabIndex = 5;
            this.lvwStudentsInCourse.UseCompatibleStateImageBehavior = false;
            // 
            // btnRemove
            // 
            this.btnRemove.BackgroundImage = global::JiTU_CS.Properties.Resources.right;
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Location = new System.Drawing.Point(424, 443);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(48, 48);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // gbAll
            // 
            this.gbAll.Controls.Add(this.btnDelete);
            this.gbAll.Controls.Add(this.btnNew);
            this.gbAll.Controls.Add(this.btnAdd);
            this.gbAll.Controls.Add(this.lvwStudentsNotInCourse);
            this.gbAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbAll.Location = new System.Drawing.Point(482, 63);
            this.gbAll.Name = "gbAll";
            this.gbAll.Padding = new System.Windows.Forms.Padding(10);
            this.gbAll.Size = new System.Drawing.Size(255, 501);
            this.gbAll.TabIndex = 0;
            this.gbAll.TabStop = false;
            this.gbAll.Text = "All other students";
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::JiTU_CS.Properties.Resources.remove;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(191, 443);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(48, 48);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackgroundImage = global::JiTU_CS.Properties.Resources.add;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(137, 443);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(48, 48);
            this.btnNew.TabIndex = 6;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::JiTU_CS.Properties.Resources.left;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(6, 443);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 48);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwStudentsNotInCourse
            // 
            this.lvwStudentsNotInCourse.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvwStudentsNotInCourse.HideSelection = false;
            this.lvwStudentsNotInCourse.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lvwStudentsNotInCourse.Location = new System.Drawing.Point(10, 23);
            this.lvwStudentsNotInCourse.Name = "lvwStudentsNotInCourse";
            this.lvwStudentsNotInCourse.Size = new System.Drawing.Size(235, 419);
            this.lvwStudentsNotInCourse.TabIndex = 4;
            this.lvwStudentsNotInCourse.UseCompatibleStateImageBehavior = false;
            this.lvwStudentsNotInCourse.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(737, 13);
            this.label1.TabIndex = 6;
            // 
            // StudentsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbCourse);
            this.Controls.Add(this.gbAll);
            this.Controls.Add(this.label1);
            this.Name = "StudentsView";
            this.Size = new System.Drawing.Size(737, 564);
            this.Resize += new System.EventHandler(this.StudentsView_Resize);
            this.Controls.SetChildIndex(this.lblMessage, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.gbAll, 0);
            this.Controls.SetChildIndex(this.gbCourse, 0);
            this.gbCourse.ResumeLayout(false);
            this.gbAll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imlMain;
        private System.Windows.Forms.GroupBox gbCourse;
        private System.Windows.Forms.GroupBox gbAll;
        private System.Windows.Forms.ListView lvwStudentsNotInCourse;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListView lvwStudentsInCourse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnAdd;
    }
}
