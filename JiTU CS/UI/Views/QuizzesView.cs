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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objective"></param>
        public QuizzesView(Objective objective) : base(objective)
        {
            InitializeComponent();

            //hide edit options base on type
            if (myObjective != Objective.ManageQuizzes)
            {
                mnsMain.Visible = false;
            }

            //clear global variable
            GlobalData.currentQuiz = null;

            //erase all items in list
            lvwQuizzes.Items.Clear();

            //decide which quizzes to add based on objective
            switch(myObjective)
            {
                case Objective.ViewAllResults:
                    {
                        lblMessage.Text = "Select Quiz to View Results for";
                        //add submitted quizzes by teacher to the list
                        List<QuizData> quizzes = QuizController.GetQuizzes(GlobalData.currentCourse);
                        foreach (QuizData quiz in quizzes)
                        {
                            if (quiz.Open != DateTime.MinValue) //determine if an open date has been set
                            {
                                ListViewItem item = lvwQuizzes.Items.Add(quiz.Name, 0);
                                item.Tag = quiz;
                            }
                        }

                        break;
                    }
                case Objective.ManageQuizzes:
                    {
                        lblMessage.Text = "Manage Quizzes";
                        //add unsubmitted teacher quizzes to the list
                        List<QuizData> quizzes = QuizController.GetQuizzes(GlobalData.currentCourse);
                        foreach (QuizData quiz in quizzes)
                        {
                            if (quiz.Open == DateTime.MinValue) //determine if an open date has been set
                            {
                                ListViewItem item = lvwQuizzes.Items.Add(quiz.Name, 0);
                                item.Tag = quiz;
                            }
                        }

                        break;
                    }
                case Objective.TakeQuiz:
                    {
                        lblMessage.Text = "Select Quiz to Take";
                        //add all opened quizzes to list
                        Entity.UserEntity temp = new JiTU_CS.Entity.UserEntity();
                        List<QuizData> quizzes = QuizController.GetQuizzes(GlobalData.currentCourse);
                        foreach (QuizData quiz in quizzes)
                        {
                            if (quiz.Open <= DateTime.Now && !temp.TestTaken(GlobalData.currentUser, quiz)) //determine if an open date is open
                            {
                                ListViewItem item = lvwQuizzes.Items.Add(quiz.Name, 0);
                                item.Tag = quiz;
                            }
                        }

                        break;
                    }
                case Objective.ViewSingleResults:
                    {
                        lblMessage.Text = "View results for which quiz?";
                        //get all opened student has taken quizzes
                        Entity.UserEntity temp = new JiTU_CS.Entity.UserEntity();
                        List<QuizData> quizzes = QuizController.GetQuizzes(GlobalData.currentCourse);
                        foreach (QuizData quiz in quizzes)
                        {
                            if (quiz.Open <= DateTime.Now && temp.TestTaken(GlobalData.currentUser, quiz)) //determine if an open date is open and theyve taken it
                            {
                                ListViewItem item = lvwQuizzes.Items.Add(quiz.Name, 0);
                                item.Tag = quiz;
                            }
                        }
                        break;
                    }
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
                //go to edit this quiz
                //create new quiz with specified name
                QuizData quizToAdd = new QuizData();
                quizToAdd.Name = quizName;

                //set global variable
                GlobalData.currentQuiz = quizToAdd;

                //go to quiz view to edit quiz
                GlobalData.currentScreen.DisplayView(new QuizView(myObjective));
                this.Dispose();
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
            GlobalData.currentScreen.DisplayView(new QuizView(myObjective));
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
            //show the form
            QuizData selectedQuiz = (QuizData)lvwQuizzes.SelectedItems[0].Tag;
            frmSubmit submitForm = new frmSubmit(selectedQuiz);
            submitForm.ShowDialog();

            //check to see if the date time was changed, if it was remove it from the list
            if (selectedQuiz.Open != DateTime.MinValue) //determine if an open date has been set
            {
                lvwQuizzes.Items.Remove(lvwQuizzes.SelectedItems[0]);
            }
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
            //decide what to do based on objective
            if (myObjective == Objective.TakeQuiz)
            {
                GlobalData.currentQuiz = (QuizData)lvwQuizzes.SelectedItems[0].Tag;
                GlobalData.currentScreen.DisplayView(new QuizView(myObjective));
                this.Dispose();
            }
            else if (myObjective == Objective.ViewAllResults)
            {
                GlobalData.currentQuiz = (QuizData)lvwQuizzes.SelectedItems[0].Tag;
                GlobalData.currentScreen.DisplayView(new QuizView(myObjective));
                this.Dispose();
            }
            else if (myObjective == Objective.ViewSingleResults)
            {
                //display students percentage on this quiz
                MessageBox.Show( "You scored " +
                    ResultsController.GetStudentPercentage(GlobalData.currentUser,(QuizData)lvwQuizzes.SelectedItems[0].Tag)
                    + "% on this quiz");
            }


        }
    }
}
