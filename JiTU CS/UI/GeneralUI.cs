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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmLogout_Click(object sender, EventArgs e)
        {
            //log user out
            GlobalData.currentUser = null;

            //remove all user controls
            foreach (Control oControl in this.Controls)
                if (oControl is UserControl)
                    oControl.Dispose();

            //display login panel
            LoginPanel newLogin = new LoginPanel();
            newLogin.Disposed += new EventHandler(loginPanel_Disposed);
            newLogin.Dock = DockStyle.Fill;
            this.Controls.Add(newLogin);
            newLogin.BringToFront();

            //hide logout button
            this.tsmLogout.Visible = false;
            

            
        }

        private void tsmLogout_VisibleChanged(object sender, EventArgs e)
        {
            this.tss_0.Visible = this.tsmLogout.Visible;
        }

        void loginPanel_Disposed(object sender, System.EventArgs e)
        {
            GlobalData.currentUser = ((LoginPanel)sender).UserLogedIn;
            login();
        }

        public void login()
        {
            //user should be logged in now
            if (GlobalData.currentUser.Role == UserData.Roles.Instructor)
            {
                Screens.InstructorScreen newScreen = new Screens.InstructorScreen();
                newScreen.Dock = DockStyle.Fill;
                this.Controls.Add(newScreen);
                newScreen.BringToFront();
                this.tsmLogout.Visible = true;
            }
            else
            {
                Screens.StudentScreen newScreen = new Screens.StudentScreen();
                newScreen.Dock = DockStyle.Fill;
                this.Controls.Add(newScreen);
                newScreen.BringToFront();
                this.tsmLogout.Visible = true;
            }
        }

    }
}
