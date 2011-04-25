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
        #region Members

        private UserData myUser;

        #endregion

        #region Properties

        public UserData UserLogedIn
        {
            get { return myUser; }
        }

        #endregion

        #region Methods

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
            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                myUser = UserController.getUser(txtUserName.Text);

                //Before considering the password, the user must exist in the database
                if (myUser != null)
                {
                    if (UserController.AuthenticateUser(myUser, txtPassword.Text))
                    {
                        this.Dispose();
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

        #endregion
    }
}
