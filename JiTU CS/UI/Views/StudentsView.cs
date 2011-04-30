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
        //contains our lists of users...
        List<UserData> studentsInCourse;
        List<UserData> studentsAll;

        public StudentsView()
        {
            InitializeComponent();

            //lblInClass
            gbCourse.Text = "Students currently enrolled in " + GlobalData.currentCourse.Name;

            //clear lists
            lvwStudentsInCourse.Items.Clear();
            lvwAllStudents.Items.Clear();

            //get the data from the controller
            studentsInCourse = UserController.GetStudents(GlobalData.currentCourse);
            studentsAll = UserController.GetStudents();

            //populate the lists
            foreach (UserData student in studentsInCourse)
            {
                lvwStudentsInCourse.Items.Add(student.FullName,0);
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
                    lvwAllStudents.Items.Add(student.FullName,0);
                }
            }
        }

        private void StudentsView_Resize(object sender, EventArgs e)
        {
            lvwStudentsInCourse.Height = gbCourse.Height - 80;
            lvwAllStudents.Height = gbCourse.Height - 80;
            btnRemove.Top = lvwStudentsInCourse.Bottom + 5;
            btnRemove.Left = gbCourse.Right - btnRemove.Width - 10;
            btnAdd.Top = btnRemove.Top;
            btnNew.Top = btnRemove.Top;
            btnDelete.Top = btnRemove.Top;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            UserData newUser = new UserData();
            newUser.Role = UserData.Roles.Student;
            frmUser user = new frmUser(newUser);
            user.ShowDialog();

            //check to see if the user was added to database... if not then we probably cancelled
            if (newUser.Id != 0)
            {
                lvwAllStudents.Items.Add(newUser.FullName);
                studentsAll.Add(newUser);
            }
        }
    }
}
