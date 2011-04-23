using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using JiTU_CS.Data;
using JiTU_CS.Controller;

namespace JiTU_CS.UI
{
    public partial class GeneralUI : Form
    {
        public GeneralUI()
        {
            InitializeComponent();
        }

        private void GeneralUI_Resize(object sender, EventArgs e)
        {
            panel2.Location = new Point((panel1.Width - panel2.Width) / 2, (panel1.Height - panel2.Height) / 2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GeneralUI_Resize(sender, e);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserData userData;
            UserController userController = new UserController();

            userData = userController.getUser(txtUserName.Text);
        }
    }
}
