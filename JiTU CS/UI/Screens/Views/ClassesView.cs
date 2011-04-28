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

            //clear list
            lvwCourses.Items.Clear();
            List<CourseData> myCourses;

            //get all logged in users classes
            myCourses = CourseController.getCourses(GlobalData.currentUser);

            //add each class to the list
            foreach (CourseData course in myCourses)
            {
<<<<<<< HEAD
                lvwCourses.Items.Add(course.name, 0);
=======
                lvwCourses.Items.Add(course.Name, "class.png");
>>>>>>> ad2c1822270d51646278606c155a0708ac4bc184
            }
        }

        private void lvwCourses_ItemActivate(object sender, EventArgs e)
        {
            mySelectedCourse = CourseController.getCourse(lvwCourses.SelectedItems[0].Text);

            this.Dispose();
        }

    }
}
