namespace JiTU_CS.UI
{
    partial class LoginPanel
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
            this.pnlBack = new System.Windows.Forms.Panel();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.MaskedTextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblJiTU = new System.Windows.Forms.Label();
            this.pnlBack.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBack
            // 
            this.pnlBack.BackColor = System.Drawing.Color.DarkGray;
            this.pnlBack.Controls.Add(this.pnlCenter);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack.Location = new System.Drawing.Point(0, 0);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(846, 551);
            this.pnlBack.TabIndex = 2;
            // 
            // pnlCenter
            // 
            this.pnlCenter.BackColor = System.Drawing.Color.LightGray;
            this.pnlCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCenter.Controls.Add(this.btnLogin);
            this.pnlCenter.Controls.Add(this.lblPassword);
            this.pnlCenter.Controls.Add(this.lblUserName);
            this.pnlCenter.Controls.Add(this.txtPassword);
            this.pnlCenter.Controls.Add(this.txtUserName);
            this.pnlCenter.Controls.Add(this.lblJiTU);
            this.pnlCenter.Location = new System.Drawing.Point(240, 162);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(368, 226);
            this.pnlCenter.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImage = global::JiTU_CS.Properties.Resources.button_back;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(20, 165);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(326, 44);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(17, 116);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(108, 26);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(17, 80);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(108, 28);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "Username";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(131, 122);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(215, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(131, 84);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(215, 20);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // lblJiTU
            // 
            this.lblJiTU.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblJiTU.Font = new System.Drawing.Font("Lucida Sans Unicode", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJiTU.Location = new System.Drawing.Point(0, 0);
            this.lblJiTU.Name = "lblJiTU";
            this.lblJiTU.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblJiTU.Size = new System.Drawing.Size(366, 60);
            this.lblJiTU.TabIndex = 0;
            this.lblJiTU.Text = "JiTU";
            this.lblJiTU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBack);
            this.Name = "LoginPanel";
            this.Size = new System.Drawing.Size(846, 551);
            this.Load += new System.EventHandler(this.LoginPanel_Load);
            this.Resize += new System.EventHandler(this.LoginPanel_Resize);
            this.pnlBack.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlCenter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBack;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.MaskedTextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblJiTU;


    }
}
