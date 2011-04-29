using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using JiTU_CS.UI.Views;
using JiTU_CS.Data;

namespace JiTU_CS.UI.Screens
{
    public partial class InstructorScreen : BaseScreen
    {
        public InstructorScreen()
        {
            InitializeComponent();

            DisplayView(new WelcomeView());
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            DisplayView(new ClassesView(ViewTypes.Students));
        }


        private void btnQuizes_Click(object sender, EventArgs e)
        {
            //create a new view, tell it where to return, then display it
            DisplayView(new ClassesView(ViewTypes.Quizzes));
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
        }

    }
}
