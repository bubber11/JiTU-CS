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

namespace JiTU_CS.UI.Screens.Views
{
    public partial class QuizzesView : BaseView
    {
        List<QuizData> quizzes;

        public QuizzesView(CourseData course)
        {
            InitializeComponent();

            //erase all items in list
            lvwQuizzes.Items.Clear();

            //add items in the course to the list
            quizzes = QuizController.GetQuizzes(course);
            foreach (QuizData quiz in quizzes)
            {
                lvwQuizzes.Items.Add(quiz.Name,0);
            }
        }

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

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string quizName = "";
            var result = Helper.InputBox("", "Enter name of quiz", ref quizName);

            if (result != DialogResult.Cancel)
            {
                //add to list
                lvwQuizzes.Items.Add(quizName, 0);

                //add to database
                QuizData quizToAdd = new QuizData();
                quizToAdd.Name = quizName;
                QuizController.SaveQuiz(quizToAdd);
                
                //add to list 
                quizzes.Add(quizToAdd);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuizData selectedQuiz;
            selectedQuiz = GetSelectedQuiz();

            if (selectedQuiz != null)
                ((BaseScreen)this.Parent.Parent.Parent).DisplayView(new QuizView(selectedQuiz));
        }

        private void submitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

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
