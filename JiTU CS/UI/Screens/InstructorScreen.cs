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
            DisplayView(new ClassesView(Objective.ManageStudents, "Manage students in which class?"));
        }


        private void btnQuizes_Click(object sender, EventArgs e)
        {
            //create a new view, tell it where to return, then display it
            DisplayView(new ClassesView(Objective.ManageQuizzes, "Manage quizzes for which class?"));
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            DisplayView(new ClassesView(Objective.ManageCourses,"Manage Courses"));
        }

        private void btnResults_Click(object sender, EventArgs e)
        {

        }

    }
}
