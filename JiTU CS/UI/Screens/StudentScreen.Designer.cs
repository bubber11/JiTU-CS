namespace JiTU_CS.UI.Screens
{
    partial class StudentScreen
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
            this.btnTakeQuiz = new System.Windows.Forms.Button();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.btnTakeQuiz);
            // 
            // btnTakeQuiz
            // 
            this.btnTakeQuiz.BackgroundImage = global::JiTU_CS.Properties.Resources.button_back;
            this.btnTakeQuiz.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTakeQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTakeQuiz.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnTakeQuiz.Location = new System.Drawing.Point(0, 0);
            this.btnTakeQuiz.Name = "btnTakeQuiz";
            this.btnTakeQuiz.Size = new System.Drawing.Size(163, 50);
            this.btnTakeQuiz.TabIndex = 1;
            this.btnTakeQuiz.Text = "Take Quiz";
            this.btnTakeQuiz.UseVisualStyleBackColor = true;
            this.btnTakeQuiz.Click += new System.EventHandler(this.btnTakeQuiz_Click);
            // 
            // StudentScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "StudentScreen";
            this.Load += new System.EventHandler(this.StudentScreen_Load);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btnTakeQuiz;

    }
}
