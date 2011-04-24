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
            foreach (Control oControl in this.Controls)
                if (oControl is UserControl)
                    oControl.Dispose();

            LoginPanel newLogin = new LoginPanel();
            newLogin.Dock = DockStyle.Fill;
            this.Controls.Add(newLogin);
            this.tsmLogout.Visible = false;
            newLogin.BringToFront();
        }

        private void tsmLogout_VisibleChanged(object sender, EventArgs e)
        {
            this.tss_0.Visible = this.tsmLogout.Visible;
        }

    }
}
