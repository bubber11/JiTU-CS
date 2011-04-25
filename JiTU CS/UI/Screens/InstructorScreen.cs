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
    public partial class InstructorScreen : BaseScreen
    {
        public InstructorScreen()
        {
            InitializeComponent();
        }

        private void InstructorScreen_Load(object sender, EventArgs e)
        {
            DisplayView(new Views.WelcomeView());
        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            
        }
    }
}
