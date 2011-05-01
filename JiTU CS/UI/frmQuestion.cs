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
        QuestionData myQuestion;

        public frmQuestion(QuestionData question)
        {
            InitializeComponent();

            myQuestion = question;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //TODO validate question is good

            //are we creating a new question or updating an old one?
            if (myQuestion == null) //new question
            {
                myQuestion = new QuestionData(0);
                myQuestion.Text = txtQuestion.Text;
                AnswerData answer;

                answer = new AnswerData(0);
                answer.Text = txtAnswer1.Text;
                myQuestion.AddAnswer(answer);

                answer = new AnswerData(0);
                answer.Text = txtAnswer2.Text;
                myQuestion.AddAnswer(answer);

                answer = new AnswerData(0);
                answer.Text = txtAnswer3.Text;
                myQuestion.AddAnswer(answer);

                answer = new AnswerData(0);
                answer.Text = txtAnswer4.Text;
                myQuestion.AddAnswer(answer);

                this.Dispose();
            }

            else
            {
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
