using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using JiTU_CS.Data;
using JiTU_CS.Controller;

namespace JiTU_CS.UI
{
    public partial class LoginPanel : UserControl
    {
        public LoginPanel()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void LoginPanel_Resize(object sender, EventArgs e)
        {
            pnlCenter.Location = new Point((pnlBack.Width - pnlCenter.Width) / 2, (pnlBack.Height - pnlCenter.Height) / 2);
        }

        private void LoginPanel_Load(object sender, EventArgs e)
        {
            LoginPanel_Resize(sender, e);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserData userData;
                UserController userController = new UserController();

                userData = userController.getUser(txtUserName.Text);

                //Before considering the password, the user must exist in the database
                if (userData != null)
                {
                    if (userController.AuthenticateUser(userData, txtPassword.Text))
                    {
                        if (userData.Role == UserData.Roles.Instructor)
                            //Navigate to the instructor's screen
                            MessageBox.Show("Instructor Validated");
                        else
                        {
                            //Navigate to the student's screen
                            try
                            {
                                GeneralUI MyParent = (GeneralUI)this.Parent;

                                UserScreen newScreen = new UserScreen();
                                newScreen.Dock = DockStyle.Fill;

                                MyParent.Controls.Add(newScreen);
                                newScreen.BringToFront();
                                MyParent.tsmLogout.Visible = true;

                                this.Dispose();
                            }
                            catch (System.Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }

                    }
                    else
                        MessageBox.Show("The User name or password is incorrect.");
                }
            }
            catch
            {
                MessageBox.Show("The User name or password is incorrect.");
            }
        }

        /// <summary>
        /// Enables the user to simply press "Enter" after providing a user name and password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnLogin_Click(sender, e);
        }


    }
}
