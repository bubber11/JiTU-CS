using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using JiTU_CS.UI.Screens.Views;

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
            DisplayView(new WelcomeView());
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            //create a new view, tell it where to return, then display it
            ClassesView classesView = new ClassesView();
            classesView.Disposed += new EventHandler(gotoStudentView);
            DisplayView(classesView);
        }

        void gotoStudentView(object sender, EventArgs e)
        {
            //make sure a class was selected
            if (((ClassesView)sender).SelectedCourse != null)
            {

            }
        }

        private void btnQuizes_Click(object sender, EventArgs e)
        {
            //create a new view, tell it where to return, then display it
            ClassesView classesView = new ClassesView();
            classesView.Disposed += new EventHandler(gotoQuizesView);
            DisplayView(classesView);
        }

        void gotoQuizesView(object sender, EventArgs e)
        {
            //make sure a class was selected
            if (((ClassesView)sender).SelectedCourse != null)
            {

            }
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            //create a new view, tell it where to return, then display it
            ClassesView classesView = new ClassesView();
            classesView.Disposed += new EventHandler(gotoResultsView);
            DisplayView(classesView);
        }

        void gotoResultsView(object sender, EventArgs e)
        {
            //make sure a class was selected
            if (((ClassesView)sender).SelectedCourse != null)
            {

            }
        }
    }
}
