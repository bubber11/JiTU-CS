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
			this.btnStudents = new System.Windows.Forms.Button();
			this.btnQuizes = new System.Windows.Forms.Button();
			this.btnResults = new System.Windows.Forms.Button();
			this.scMain.Panel1.SuspendLayout();
			this.scMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// scMain
			// 
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.Controls.Add(this.btnResults);
			this.scMain.Panel1.Controls.Add(this.btnQuizes);
			this.scMain.Panel1.Controls.Add(this.btnStudents);
			this.scMain.Size = new System.Drawing.Size(757, 501);
			// 
			// btnStudents
			// 
			this.btnStudents.BackgroundImage = global::JiTU_CS.Properties.Resources.button_back;
			this.btnStudents.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnStudents.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnStudents.Location = new System.Drawing.Point(0, 0);
			this.btnStudents.Name = "btnStudents";
			this.btnStudents.Size = new System.Drawing.Size(163, 50);
			this.btnStudents.TabIndex = 2;
			this.btnStudents.Text = "Students";
			this.btnStudents.UseVisualStyleBackColor = true;
			this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
			// 
			// btnQuizes
			// 
			this.btnQuizes.BackgroundImage = global::JiTU_CS.Properties.Resources.button_back;
			this.btnQuizes.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnQuizes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnQuizes.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnQuizes.Location = new System.Drawing.Point(0, 50);
			this.btnQuizes.Name = "btnQuizes";
			this.btnQuizes.Size = new System.Drawing.Size(163, 50);
			this.btnQuizes.TabIndex = 3;
			this.btnQuizes.Text = "Quizzes";
			this.btnQuizes.UseVisualStyleBackColor = true;
			this.btnQuizes.Click += new System.EventHandler(this.btnQuizes_Click);
			// 
			// btnResults
			// 
			this.btnResults.BackgroundImage = global::JiTU_CS.Properties.Resources.button_back;
			this.btnResults.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnResults.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnResults.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnResults.Location = new System.Drawing.Point(0, 100);
			this.btnResults.Name = "btnResults";
			this.btnResults.Size = new System.Drawing.Size(163, 50);
			this.btnResults.TabIndex = 4;
			this.btnResults.Text = "Results";
			this.btnResults.UseVisualStyleBackColor = true;
			this.btnResults.Click += new System.EventHandler(this.btnResults_Click);
			// 
			// InstructorScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "InstructorScreen";
			this.Size = new System.Drawing.Size(757, 501);
			this.scMain.Panel1.ResumeLayout(false);
			this.scMain.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btnStudents;
        protected System.Windows.Forms.Button btnQuizes;
        protected System.Windows.Forms.Button btnResults;
    }
}
