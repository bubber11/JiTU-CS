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
    /// Draws a list of classes to select or if specified allows you to manage them
    /// </summary>
    public partial class ClassesView : BaseView
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objective">whats the objective?</param>
        /// <param name="messageText">text to display</param>
        public ClassesView(Objective objective, string messageText) : base(objective)
        {
            InitializeComponent();

            //change message text
            lblMessage.Text = messageText;

            //copy objective
            myObjective = objective;

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

            //change visibility based on view type
            if (myObjective == Objective.ManageCourses)
            {
                mnsMain.Visible = true;
            }
            else
            {
                mnsMain.Visible = false;
            }
        }

        /// <summary>
        /// event handler for course list item activate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvwCourses_ItemActivate(object sender, EventArgs e)
        {
            //decide which view to go to next
            switch (myObjective)
            {
                case Objective.ManageQuizzes:
                    {
                        GlobalData.currentCourse = (CourseData)lvwCourses.SelectedItems[0].Tag;
                        GlobalData.currentScreen.DisplayView(new QuizzesView(myObjective));
                        this.Dispose();
                        break;
                    }
                case Objective.ManageStudents:
                    {
                        GlobalData.currentCourse = (CourseData)lvwCourses.SelectedItems[0].Tag;
                        GlobalData.currentScreen.DisplayView(new StudentsView());
                        this.Dispose();
                        break;
                    }
                case Objective.TakeQuiz:
                    {
                        GlobalData.currentCourse = (CourseData)lvwCourses.SelectedItems[0].Tag;
                        GlobalData.currentScreen.DisplayView(new QuizzesView(myObjective));
                        this.Dispose();
                        break;
                    }
                case Objective.ViewAllResults:
                    {
                        GlobalData.currentCourse = (CourseData)lvwCourses.SelectedItems[0].Tag;
                        GlobalData.currentScreen.DisplayView(new QuizzesView(myObjective));
                        this.Dispose();
                        break;
                    }
                case Objective.ViewSingleResults:
                    {
                        GlobalData.currentCourse = (CourseData)lvwCourses.SelectedItems[0].Tag;
                        GlobalData.currentScreen.DisplayView(new QuizzesView(myObjective));
                        this.Dispose();
                        break;
                    }
            }
            
        }

        /// <summary>
        /// event handler for course list selected index change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvwCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (myObjective == Objective.ManageCourses)
            {
                //control button enables
                if (lvwCourses.SelectedItems.Count > 0)
                {
                    editToolStripMenuItem.Enabled = true;
                    removeToolStripMenuItem.Enabled = true;
                }
                else
                {
                    editToolStripMenuItem.Enabled = false;
                    removeToolStripMenuItem.Enabled = false;
                }
            }
        }

        /// <summary>
        /// handles click event for edit button in manage mode.
        /// allows user to change name of course.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //get our selected course
            CourseData selectedCourse = (CourseData)lvwCourses.SelectedItems[0].Tag;

            //prompt user for new name
            string courseName = "";
            var result = HelperUI.InputBox("Renaming " + selectedCourse.Name, "Enter new name of course", ref courseName);

            //determine if user pressed okay
            if (result == DialogResult.OK)
            {
                //change name
                selectedCourse.Name = courseName;
                lvwCourses.SelectedItems[0].Text = courseName;
                //save it to database
                CourseController.SaveCourse(selectedCourse);
            }
        }

        /// <summary>
        /// handles add course button click. allows user to add a new course.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prompt user for name of new course
            string courseName = "";
            var result = HelperUI.InputBox("New Course", "Enter name of course", ref courseName);

            //if user selected okay
            if (result == DialogResult.OK)
            {
                //add to database
                CourseData courseToAdd = new CourseData();
                courseToAdd.Name = courseName;
                CourseController.SaveCourse(courseToAdd);
                CourseController.AddUser(courseToAdd, GlobalData.currentUser);

                //add to list
                ListViewItem item = lvwCourses.Items.Add(courseToAdd.Name,0);
                item.Tag = courseToAdd;
            }
        }

        /// <summary>
        /// handles remove button click event. allows user to remove the
        /// selected course.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //get the selected course
            CourseData courseToRemove = (CourseData)lvwCourses.SelectedItems[0].Tag;
            
            //prompt user if they want to delete it
            var result = MessageBox.Show("Are you sure you want to permanently delete " + courseToRemove.Name + "?", "Warning!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //remove from list
                lvwCourses.Items.Remove(lvwCourses.SelectedItems[0]);
                //remove from database
                CourseController.DeleteCourse(courseToRemove);
            }

        }

    }
}
