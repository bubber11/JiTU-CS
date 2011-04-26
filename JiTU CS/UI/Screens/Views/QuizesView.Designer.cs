namespace JiTU_CS.UI.Screens.Views
{
    partial class QuizesView
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Quiz 1", 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizesView));
            this.lvwQuizes = new System.Windows.Forms.ListView();
            this.imlQuizes = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Text = "Quizes";
            // 
            // lvwQuizes
            // 
            this.lvwQuizes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwQuizes.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvwQuizes.LargeImageList = this.imlQuizes;
            this.lvwQuizes.Location = new System.Drawing.Point(0, 55);
            this.lvwQuizes.Name = "lvwQuizes";
            this.lvwQuizes.Size = new System.Drawing.Size(674, 507);
            this.lvwQuizes.TabIndex = 2;
            this.lvwQuizes.UseCompatibleStateImageBehavior = false;
            // 
            // imlQuizes
            // 
            this.imlQuizes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlQuizes.ImageStream")));
            this.imlQuizes.TransparentColor = System.Drawing.Color.Transparent;
            this.imlQuizes.Images.SetKeyName(0, "quiz.gif");
            // 
            // QuizesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvwQuizes);
            this.Name = "QuizesView";
            this.Controls.SetChildIndex(this.lblMessage, 0);
            this.Controls.SetChildIndex(this.lvwQuizes, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwQuizes;
        private System.Windows.Forms.ImageList imlQuizes;
    }
}
