using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using JiTU_CS.UI.Screens.Views;

namespace JiTU_CS.UI.Screens
{
    public partial class StudentScreen : BaseScreen
    {
        public StudentScreen()
        {
            InitializeComponent();
        }

        private void StudentScreen_Load(object sender, EventArgs e)
        {
            DisplayView(new Views.WelcomeView());
        }

        private void btnTakeQuiz_Click(object sender, EventArgs e)
        {
            //create a new view, tell it where to return, then display it
            ClassesView classesView = new ClassesView();
            classesView.Disposed += new EventHandler(gotoquizzesView);
            DisplayView(classesView);
        }

        private void gotoquizzesView(object sender, EventArgs e)
        {
            //make sure a class was selected
            if (((ClassesView)sender).SelectedCourse != null)
            {

            }
        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
            //create a new view, tell it where to return, then display it
            ClassesView classesView = new ClassesView();
            classesView.Disposed += new EventHandler(gotoResultsView);
            DisplayView(classesView);
        }

        private void gotoResultsView(object sender, EventArgs e)
        {
            //make sure a class was selected
            if (((ClassesView)sender).SelectedCourse != null)
            {

            }
        }
    }
}
