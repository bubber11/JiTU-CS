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
            UserData userData;
            UserController userController = new UserController();

            userData = userController.getUser(txtUserName.Text);
        }


    }
}
