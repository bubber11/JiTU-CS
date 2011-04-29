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
        public ClassesView()
        {
            InitializeComponent();

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
                lvwCourses.Items.Add(course.Name, 0);
            }
        }

        private void lvwCourses_ItemActivate(object sender, EventArgs e)
        {
            GlobalData.currentCourse = CourseController.GetCourse(lvwCourses.SelectedItems[0].Text);

            this.Dispose();
        }

    }
}
