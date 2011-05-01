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
using JiTU_CS.UI;

namespace JiTU_CS.UI.Views
{
    public partial class QuizzesView : BaseView
    {
        public enum QuizzesViewType { select, manage };
        private QuizzesViewType myType;


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="type">The type to show</param>
        public QuizzesView(QuizzesViewType type)
        {
            InitializeComponent();

            //copy type
            myType = type;

            //hide edit options base on type
            if (myType == QuizzesViewType.select)
            {
                mnsMain.Visible = false;
            }

            //clear global variable
            GlobalData.currentQuiz = null;

            //erase all items in list
            lvwQuizzes.Items.Clear();

            //add items in the course to the list
            List<QuizData> quizzes = QuizController.GetQuizzes(GlobalData.currentCourse);
            foreach (QuizData quiz in quizzes)
            {
                ListViewItem item = lvwQuizzes.Items.Add(quiz.Name,0);
                item.Tag = quiz;
            }
        }

        /// <summary>
        /// Handles remove button click event.
        /// Removes the current selected quiz from the current course
        /// </summary>
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuizData quizToRemove = (QuizData)lvwQuizzes.SelectedItems[0].Tag;

            //prompt user if they want to delete it
            var result = MessageBox.Show("Are you sure you want to permanently delete " + quizToRemove.Name + "?", "Warning!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //remove quiz from list
                lvwQuizzes.Items.Remove(lvwQuizzes.SelectedItems[0]);

                //remove quiz from database
                QuizController.DeleteQuiz(quizToRemove);
            }
        }

        /// <summary>
        /// Handles add button click event.
        /// Allows user to add a quiz to the current selected course
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prompt user for name
            string quizName = "";
            var result = HelperUI.InputBox("", "Enter name of quiz", ref quizName);

            //if user selected ok
            if (result == DialogResult.OK)
            {
                //add to database
                QuizData quizToAdd = new QuizData();
                quizToAdd.Name = quizName;
                QuizController.SaveQuiz(quizToAdd);
                CourseController.AddQuiz(GlobalData.currentCourse, quizToAdd);
                
                //add to list 
                ListViewItem item = lvwQuizzes.Items.Add(quizToAdd.Name);
                item.Tag = quizToAdd;
            }
        }

        /// <summary>
        /// Handles edit button click event.
        /// Takes user to an editable version of the quiz currently selected
        /// </summary>
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set global variable
            GlobalData.currentQuiz = (QuizData)lvwQuizzes.SelectedItems[0].Tag;

            //go to quiz view to edit quiz
            GlobalData.currentScreen.DisplayView(new QuizView(QuizView.QuizViewType.edit));
            this.Dispose();
        }

        /// <summary>
        ///  Handles submit button click event.
        ///  Allows user to set open date and close date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO add submit code here
        }

        /// <summary>
        /// Handles quizzes list change index event.
        /// Changes available options based on what is selected.
        /// </summary>
        private void lvwQuizzes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if no items are selected
            if (lvwQuizzes.SelectedItems.Count == 0)
            {
                submitToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                removeToolStripMenuItem.Enabled = false;
            }
            //if a quiz is selected
            else 
            {
                submitToolStripMenuItem.Enabled = true;
                editToolStripMenuItem.Enabled = true;
                removeToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// Handles quiz list double click event
        /// If type is select then we take the quiz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quizSelectedMenuItem_DoubleClick(object sender, EventArgs e) 
        {
            //if type is select then take the quiz
            if (myType == QuizzesViewType.select)
            {
                GlobalData.currentQuiz = (QuizData)lvwQuizzes.SelectedItems[0].Tag;
                GlobalData.currentScreen.DisplayView(new QuizView(QuizView.QuizViewType.take));
                this.Dispose();
            }

        }
    }
}
