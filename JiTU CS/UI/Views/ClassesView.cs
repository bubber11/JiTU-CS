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
        #region Members
        public enum ClassesViewType { Manage, Select };
        private ViewTypes myNextView;
        private ClassesViewType myViewType;
        #endregion

        /// <summary>
        /// Create the view
        /// </summary>
        /// <param name="nextView">what view to go to next</param>
        /// <param name="messageText">the text to display</param>
        /// <param name="type">what type of course view</param>
        public ClassesView(ViewTypes nextView, string messageText, ClassesViewType type)
        {
            InitializeComponent();

            //copy view type
            myViewType = type;

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

            //change visibility based on view type
            if (type == ClassesViewType.Select)
            {
                mnsMain.Visible = false;
            }
            else
            {
            }
        }

        /// <summary>
        /// event handler for course list item activate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvwCourses_ItemActivate(object sender, EventArgs e)
        {
            //if we are in select mode go to the next specified screen
            if (myViewType == ClassesViewType.Select)
            {
                //tell global varable which course we selected
                GlobalData.currentCourse = (CourseData)lvwCourses.SelectedItems[0].Tag;

                //decide which view to go to next
                if (myNextView == ViewTypes.Quizzes)
                {
                    GlobalData.currentScreen.DisplayView(new QuizzesView(QuizzesView.QuizzesViewType.select));
                }
                if (myNextView == ViewTypes.Students)
                {
                    GlobalData.currentScreen.DisplayView(new StudentsView());
                }

                //were done selecting course so delete this
                this.Dispose();
            }
        }

        /// <summary>
        /// event handler for course list selected index change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvwCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (myViewType == ClassesViewType.Manage)
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
