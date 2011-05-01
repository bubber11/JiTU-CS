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
        List<QuizData> quizzes; //list of quizzes that show up in the list view

        /// <summary>
        /// constructor
        /// </summary>
        public QuizzesView()
        {
            InitializeComponent();

            //clear global variable
            GlobalData.currentQuiz = null;

            //erase all items in list
            lvwQuizzes.Items.Clear();

            if (GlobalData.currentUser.Role != UserData.Roles.Instructor)
                mnsMain.Visible = false;

            //add items in the course to the list
            quizzes = QuizController.GetQuizzes(GlobalData.currentCourse);
            foreach (QuizData quiz in quizzes)
            {
                lvwQuizzes.Items.Add(quiz.Name,0);
            }
        }

        /// <summary>
        /// returns the current selected quiz in the list view
        /// </summary>
        /// <returns>the quiz that was selected</returns>
        private QuizData GetSelectedQuiz()
        {
            //find the quiz weve selected from text
            if (lvwQuizzes.SelectedItems.Count != 0)
            {
                foreach (QuizData quiz in quizzes)
                {
                    if (quiz.Name == lvwQuizzes.SelectedItems[0].Text)
                    {
                        return quiz;
                    }
                }
            }

            //no quiz is selected
            return null;
        }

        /// <summary>
        /// removes the current selected quiz from the current course
        /// </summary>
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuizData quizToRemove;
            quizToRemove = GetSelectedQuiz();

            if (quizToRemove != null)
            {
                //prompt user if they want to delete it
                var result = MessageBox.Show("Are you sure you want to permanently delete " + quizToRemove.Name + "?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //remove quiz from list
                    lvwQuizzes.Items.Remove(lvwQuizzes.SelectedItems[0]);

                    //remove quiz from database
                    QuizController.DeleteQuiz(quizToRemove);

                    //remove from quiz list
                    quizzes.Remove(quizToRemove);
                }
            }
        }

        /// <summary>
        /// allows you to add a quiz to the current selected course
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string quizName = "";
            var result = HelperUI.InputBox("", "Enter name of quiz", ref quizName);

            if (result != DialogResult.Cancel)
            {
                //add to list
                lvwQuizzes.Items.Add(quizName, 0);

                //add to database
                QuizData quizToAdd = new QuizData();
                quizToAdd.Name = quizName;
                QuizController.SaveQuiz(quizToAdd);
                CourseController.AddQuiz(GlobalData.currentCourse, quizToAdd);
                
                //add to list 
                quizzes.Add(quizToAdd);
            }
        }

        /// <summary>
        /// takes you to a editable version of the quiz currently selected
        /// </summary>
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalData.currentQuiz = GetSelectedQuiz();
            this.Dispose();
            GlobalData.currentScreen.DisplayView(new QuizView(QuizView.QuizViewType.edit));
        }

        private void submitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO add submit code here
        }

        /// <summary>
        /// changes available options based on what is selected
        /// </summary>
        private void lvwQuizzes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwQuizzes.SelectedItems.Count == 0)
            {
                submitToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                removeToolStripMenuItem.Enabled = false;
            }
            else
            {
                submitToolStripMenuItem.Enabled = true;
                editToolStripMenuItem.Enabled = true;
                removeToolStripMenuItem.Enabled = true;
            }
        }

    }
}
