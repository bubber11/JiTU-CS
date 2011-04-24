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
    public partial class InstructorScreen : UserScreen
    {
        WelcomeScreen welcomeScreen;

        public InstructorScreen()
        {
            InitializeComponent();
        }

        private void InstructorScreen_Load(object sender, EventArgs e)
        {
            welcomeScreen = new WelcomeScreen();
            welcomeScreen.Dock = DockStyle.Fill;

            scMain.Panel2.Controls.Add(welcomeScreen);
        }
    }
}
