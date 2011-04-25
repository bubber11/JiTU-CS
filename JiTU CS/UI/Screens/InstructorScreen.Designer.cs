namespace JiTU_CS.UI.Screens
{
    partial class InstructorScreen
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
            this.btnManageStudents = new System.Windows.Forms.Button();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.btnManageStudents);
            this.scMain.Size = new System.Drawing.Size(757, 501);
            // 
            // btnManageStudents
            // 
            this.btnManageStudents.BackgroundImage = global::JiTU_CS.Properties.Resources.button_back;
            this.btnManageStudents.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageStudents.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnManageStudents.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnManageStudents.Location = new System.Drawing.Point(0, 0);
            this.btnManageStudents.Name = "btnManageStudents";
            this.btnManageStudents.Size = new System.Drawing.Size(163, 50);
            this.btnManageStudents.TabIndex = 2;
            this.btnManageStudents.Text = "Manage Students";
            this.btnManageStudents.UseVisualStyleBackColor = true;
            this.btnManageStudents.Click += new System.EventHandler(this.btnManageStudents_Click);
            // 
            // InstructorScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "InstructorScreen";
            this.Size = new System.Drawing.Size(757, 501);
            this.Load += new System.EventHandler(this.InstructorScreen_Load);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btnManageStudents;
    }
}
