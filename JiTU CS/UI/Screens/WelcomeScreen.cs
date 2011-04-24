using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JiTU_CS.UI.Screens
{
    public partial class WelcomeScreen : UserControl
    {
        public WelcomeScreen()
        {
            InitializeComponent();
        }

        private void WelcomeScreen_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome " + GlobalData.currentUser.FullName + "!";
        }
    }
}
