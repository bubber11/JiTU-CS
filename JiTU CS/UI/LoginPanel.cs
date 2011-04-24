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
                            //Navigate to the student's screen
                            MessageBox.Show("Student Student Validated");
                    }
                    else
                        MessageBox.Show("The User name or password is incorrect.");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("The User name or password is incorrect.");
            }
        }


    }
}
