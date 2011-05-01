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
    /// <summary>
    /// Displays a view that allows the user to manage students in a specific course
    /// </summary>
    public partial class StudentsView : BaseView
    {
        /// <summary>
        /// Default constructor, draws elements and populates the lsits
        /// </summary>
        public StudentsView() : base(Objective.ManageStudents)
        {
            //create form components
            InitializeComponent();

            //lblInClass
            gbCourse.Text = "Students currently enrolled in " + GlobalData.currentCourse.Name;

            //clear lists
            lvwStudentsInCourse.Items.Clear();
            lvwStudentsNotInCourse.Items.Clear();

            List<UserData> studentsInCourse;
            List<UserData> studentsNotInCourse;

            //get the data from the controller
            studentsInCourse = UserController.GetStudents(GlobalData.currentCourse);
            studentsNotInCourse = UserController.GetStudents();

            //remove students in course from students out of class list
            //first find all the students to remove
            List<UserData> studentsToRemove = new List<UserData>();
            foreach (UserData studentNotInCourse in studentsNotInCourse)
            {
                foreach (UserData studentInCourse in studentsInCourse)
                {
                    if (studentInCourse.Id == studentNotInCourse.Id)
                    {
                        studentsToRemove.Add(studentNotInCourse); //we found student in the course so remove
                        break; //goto next student in list not in class
                    }
                }
            }
            //now remove them
            foreach (UserData student in studentsToRemove)
            {
                studentsNotInCourse.Remove(student);
            }

            //populate the lists
            foreach (UserData student in studentsInCourse)
            {
                ListViewItem item = lvwStudentsInCourse.Items.Add(student.FullName, 0);
                item.Tag = student;
            }
            foreach (UserData student in studentsNotInCourse)
            {
                ListViewItem item = lvwStudentsNotInCourse.Items.Add(student.FullName, 0);
                item.Tag = student;
            }

            
        }

        /// <summary>
        /// Handles panel resize event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentsView_Resize(object sender, EventArgs e)
        {
            lvwStudentsInCourse.Height = gbCourse.Height - 80;
            lvwStudentsNotInCourse.Height = gbCourse.Height - 80;
            btnRemove.Top = lvwStudentsInCourse.Bottom + 5;
            btnRemove.Left = gbCourse.Right - btnRemove.Width - 10;
            btnAdd.Top = btnRemove.Top;
            btnNew.Top = btnRemove.Top;
            btnDelete.Top = btnRemove.Top;

        }

        /// <summary>
        /// Handles click event for new student button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            UserData newUser = new UserData();
            newUser.Role = UserData.Roles.Student;
            frmUser user = new frmUser(newUser);
            user.ShowDialog();

            //check to see if the user was added to database... if not then we probably cancelled
            if (newUser.Id != 0)
            {
                //add user to user list
                ListViewItem item = lvwStudentsNotInCourse.Items.Add(newUser.FullName, 0);
                item.Tag = newUser;
            }
        }

        /// <summary>
        /// handles click event for delete student button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //prompt for user conformation
            var result = MessageBox.Show("Are you sure you want to delete all this students? This will be permanent.", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //check students in course
                while (lvwStudentsInCourse.SelectedItems.Count > 0)
                {
                    //get selected item
                    ListViewItem item = lvwStudentsInCourse.SelectedItems[0];
                    lvwStudentsInCourse.Items.Remove(item); //remove from list

                    //make changes in database
                    UserData studentToRemove = (UserData)item.Tag;
                    UserController.DeleteUser(studentToRemove);
                }
                //check students not in course
                while (lvwStudentsNotInCourse.SelectedItems.Count > 0)
                {
                    //get selected item
                    ListViewItem item = lvwStudentsNotInCourse.SelectedItems[0];
                    lvwStudentsNotInCourse.Items.Remove(item); //remove from list

                    //make changes in database
                    UserData studentToRemove = (UserData)item.Tag;
                    UserController.DeleteUser(studentToRemove);
                }
            }
        }

        /// <summary>
        /// Handles click event for remove student from course button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            while (lvwStudentsInCourse.SelectedItems.Count > 0)
            {
                ListViewItem item = lvwStudentsInCourse.SelectedItems[0];
                lvwStudentsInCourse.Items.Remove(item); //remove from list
                lvwStudentsNotInCourse.Items.Add(item); //add to list

                //make changes in database
                UserData studentToRemove = (UserData)item.Tag;
                CourseController.RemoveUser(GlobalData.currentCourse, studentToRemove);
            }
        }

        /// <summary>
        /// Handles click event for add student to course button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            while (lvwStudentsNotInCourse.SelectedItems.Count > 0)
            {
                ListViewItem item = lvwStudentsNotInCourse.SelectedItems[0];
                lvwStudentsNotInCourse.Items.Remove(item); //remove from list
                lvwStudentsInCourse.Items.Add(item); //add to list

                //make changes in database
                UserData studentToAdd = (UserData)item.Tag;
                CourseController.AddUser(GlobalData.currentCourse, studentToAdd);
            }
        }


    }
}
