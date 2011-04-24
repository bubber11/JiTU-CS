namespace JiTU_CS.UI.Screens
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
            this.welcomeScreen = new JiTU_CS.UI.Screens.WelcomeScreen();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.BackColor = System.Drawing.Color.Maroon;
            this.scMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.IsSplitterFixed = true;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(108)))), ((int)(((byte)(78)))));
            this.scMain.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.scMain.Panel2.Controls.Add(this.welcomeScreen);
            this.scMain.Size = new System.Drawing.Size(667, 468);
            this.scMain.SplitterDistance = 165;
            this.scMain.SplitterWidth = 2;
            this.scMain.TabIndex = 0;
            // 
            // welcomeScreen
            // 
            this.welcomeScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomeScreen.Location = new System.Drawing.Point(0, 0);
            this.welcomeScreen.Name = "welcomeScreen";
            this.welcomeScreen.Size = new System.Drawing.Size(498, 466);
            this.welcomeScreen.TabIndex = 0;
            // 
            // UserScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scMain);
            this.Name = "UserScreen";
            this.Size = new System.Drawing.Size(667, 468);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.SplitContainer scMain;
        private WelcomeScreen welcomeScreen;
    }
}
