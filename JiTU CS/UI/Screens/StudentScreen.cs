using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JiTU_CS.UI.Screens
{
    public partial class StudentScreen : UserScreen
    {
        WelcomeScreen welcomeScreen;

        public StudentScreen()
        {
            InitializeComponent();
        }

        private void StudentScreen_Load(object sender, EventArgs e)
        {
            welcomeScreen = new WelcomeScreen();
            welcomeScreen.Dock = DockStyle.Fill;

            scMain.Panel2.Controls.Add(welcomeScreen);
        }

    }
}
