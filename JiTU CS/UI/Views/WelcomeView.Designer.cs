﻿namespace JiTU_CS.UI.Views
{
    partial class WelcomeView
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
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Size = new System.Drawing.Size(633, 50);
            // 
            // WelcomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "WelcomeView";
            this.Size = new System.Drawing.Size(633, 451);
            this.Load += new System.EventHandler(this.WelcomeView_Load);
            this.ResumeLayout(false);

        }

        #endregion



    }
}
