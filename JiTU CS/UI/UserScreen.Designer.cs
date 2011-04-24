namespace JiTU_CS.UI
{
    partial class UserScreen
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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.btnTakeQuiz = new System.Windows.Forms.Button();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(108)))), ((int)(((byte)(78)))));
            this.scMain.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.scMain.Panel1.Controls.Add(this.btnTakeQuiz);
            this.scMain.Size = new System.Drawing.Size(667, 468);
            this.scMain.SplitterDistance = 165;
            this.scMain.TabIndex = 0;
            // 
            // btnTakeQuiz
            // 
            this.btnTakeQuiz.BackgroundImage = global::JiTU_CS.Properties.Resources.button_back;
            this.btnTakeQuiz.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTakeQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTakeQuiz.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnTakeQuiz.Location = new System.Drawing.Point(0, 0);
            this.btnTakeQuiz.Name = "btnTakeQuiz";
            this.btnTakeQuiz.Size = new System.Drawing.Size(165, 50);
            this.btnTakeQuiz.TabIndex = 0;
            this.btnTakeQuiz.Text = "Take Quiz";
            this.btnTakeQuiz.UseVisualStyleBackColor = true;
            // 
            // UserScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scMain);
            this.Name = "UserScreen";
            this.Size = new System.Drawing.Size(667, 468);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Button btnTakeQuiz;
    }
}
