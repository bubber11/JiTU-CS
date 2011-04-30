using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JiTU_CS.Data;
using JiTU_CS.Controller;

namespace JiTU_CS.UI.Views
{
    public partial class ClassesView : BaseView
    {        
        private ViewTypes myNextView;

        /// <summary>
        /// Create a new view and specify the view to go to after a course is selected
        /// and the text that displays in the message
        /// </summary>
        /// <param name="nextView">the next view to be displayed</param>
        /// <param name="messageText">the text the message will display</param>
        public ClassesView(ViewTypes nextView, string messageText)
        {
            InitializeComponent();

            //change message text
            lblMessage.Text = messageText;

            //copy nextview
            myNextView = nextView;

            //clear global variable
            GlobalData.currentCourse = null;

            //clear list
            lvwCourses.Items.Clear();
            List<CourseData> myCourses;

            //get all logged in users classes
            myCourses = CourseController.GetCourses(GlobalData.currentUser);

            //add each class to the list
            foreach (CourseData course in myCourses)
            {
                ListViewItem item = lvwCourses.Items.Add(course.Name, 0);
                item.Tag = course;
            }
        }

        private void lvwCourses_ItemActivate(object sender, EventArgs e)
        {
            GlobalData.currentCourse = (CourseData)lvwCourses.SelectedItems[0].Tag;

			

            if (myNextView == ViewTypes.Quizzes)
            {
                GlobalData.currentScreen.DisplayView(new QuizzesView());
            }
            if (myNextView == ViewTypes.Students)
            {
                GlobalData.currentScreen.DisplayView(new StudentsView());
            }

            this.Dispose();
        }

    }
}
