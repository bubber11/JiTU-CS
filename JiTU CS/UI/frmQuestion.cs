using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JiTU_CS.Data;

namespace JiTU_CS.UI
{
    public partial class frmQuestion : Form
    {
        QuestionData externalQuestion;
        bool isNewQuestion;

        /// <summary>
        /// Default Constructor
        /// Stores references to external variables
        /// </summary>
        /// <param name="question">question to be editing</param>
        public frmQuestion(QuestionData question)
        {
            externalQuestion = question; //copy external reference
            isNewQuestion = (question.Answers.Count == 0); //if we have no questions, we know were new

            InitializeComponent();

            //if we have data then display it
            if (externalQuestion.Answers.Count > 0)
            {
                txtQuestion.Text = externalQuestion.Text;
                txtAnswer1.Text = externalQuestion.Answers[0].Text;
                txtAnswer2.Text = externalQuestion.Answers[1].Text;
                txtAnswer3.Text = externalQuestion.Answers[2].Text;
                txtAnswer4.Text = externalQuestion.Answers[3].Text;
                rbtn1.Checked = externalQuestion.Answers[0].Correct;
                rbtn2.Checked = externalQuestion.Answers[1].Correct;
                rbtn3.Checked = externalQuestion.Answers[2].Correct;
                rbtn4.Checked = externalQuestion.Answers[3].Correct;
            }
        }

        /// <summary>
        /// Handles form closing event. If answer was new and unfinished
        /// we create a flag so that its known to be invalid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmQuestion_Disposed(object sender, System.EventArgs e)
        {
            //if new question, flag that it was cancelled
            if (isNewQuestion)
            {
                externalQuestion.Id = -1; //flag it as invalid
            }

            //if not new question dont do anything, just close
        }

        /// <summary>
        /// handles ok button click event.
        /// Updates external reference if question is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //TODO validate question is good

            //are we creating a new question or updating an old one?
            if (isNewQuestion) //new question
            {

                externalQuestion.Text = txtQuestion.Text;
                AnswerData answer;

                answer = new AnswerData(0);
                answer.Text = txtAnswer1.Text;
                answer.Correct = rbtn1.Checked;
                externalQuestion.AddAnswer(answer);

                answer = new AnswerData(0);
                answer.Text = txtAnswer2.Text;
                answer.Correct = rbtn2.Checked;
                externalQuestion.AddAnswer(answer);

                answer = new AnswerData(0);
                answer.Text = txtAnswer3.Text;
                answer.Correct = rbtn3.Checked;
                externalQuestion.AddAnswer(answer);

                answer = new AnswerData(0);
                answer.Text = txtAnswer4.Text;
                answer.Correct = rbtn4.Checked;
                externalQuestion.AddAnswer(answer);

                this.Disposed -= frmQuestion_Disposed;
                this.Dispose();
            }
            //change the old question
            else
            {
                externalQuestion.Text = txtQuestion.Text;
                externalQuestion.Answers[0].Text = txtAnswer1.Text;
                externalQuestion.Answers[0].Correct = rbtn1.Checked;
                externalQuestion.Answers[1].Text = txtAnswer2.Text;
                externalQuestion.Answers[1].Correct = rbtn2.Checked;
                externalQuestion.Answers[2].Text = txtAnswer3.Text;
                externalQuestion.Answers[2].Correct = rbtn3.Checked;
                externalQuestion.Answers[3].Text = txtAnswer4.Text;
                externalQuestion.Answers[3].Correct = rbtn4.Checked;

                this.Disposed -= frmQuestion_Disposed;
                this.Dispose();
            }


        }

        /// <summary>
        /// handles cancel button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
