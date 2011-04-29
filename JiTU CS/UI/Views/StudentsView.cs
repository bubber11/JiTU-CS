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
    public partial class StudentsView : BaseView
    {
        List<UserData> studentsInCourse;
        List<UserData> studentsAll;

        public StudentsView(CourseData course)
        {
            InitializeComponent();

            //clear lists
            lvwStudentsInCourse.Items.Clear();
            lvwAllStudents.Items.Clear();

            //get the data from the controller
            studentsInCourse = UserController.GetStudents(course);
            studentsAll = UserController.GetStudents();

            //populate the lists
            foreach (UserData student in studentsInCourse)
            {
                lvwStudentsInCourse.Items.Add(student.FullName);
            }

            bool alreadyExists;
            foreach (UserData student in studentsAll)
            {
                alreadyExists = false;
                foreach (UserData studentInCourse in studentsInCourse)
                {
                    if (studentInCourse.FullName == student.FullName)
                    {
                        alreadyExists = true;
                        break;
                    }
                }
                
                if (!alreadyExists)
                {
                    lvwAllStudents.Items.Add(student.FullName);
                }
            }
        }
    }
}
