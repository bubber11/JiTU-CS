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

namespace JiTU_CS.UI.Screens.Views
{
    public partial class ClassesView : BaseView
    {
        private CourseData mySelectedCourse;

        public CourseData SelectedCourse
        {
            get
            {
                return mySelectedCourse;
            }
        }

        public ClassesView()
        {
            InitializeComponent();

            lvwCourses.Items.Clear();
            List<CourseData> myCourses;

            myCourses = CourseController.getCourses(GlobalData.currentUser);

            foreach (CourseData course in myCourses)
            {
                lvwCourses.Items.Add(course.name, "class.png");
            }
        }

        private void lvwCourses_ItemActivate(object sender, EventArgs e)
        {
            mySelectedCourse = CourseController.getCourse(lvwCourses.SelectedItems[0].Text);

            this.Dispose();
        }

    }
}
