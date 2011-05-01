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
    public partial class QuizView : BaseView
    {
        public enum QuizViewType { edit, take };

        private List<QuestionBox> questionBoxes;
        private Button submitButton;

        private QuizViewType __type;

        public QuizView(QuizViewType type) {

            InitializeComponent();

            //set title
            lblMessage.Text = GlobalData.currentQuiz.Name;

            __type = type;

            questionBoxes = new List<QuestionBox>();

            for (int i = 0; i < GlobalData.currentQuiz.Questions.Count; i++)
            {
                QuestionBox questionBox = new QuestionBox(GlobalData.currentQuiz.Questions[i], i + 1, __type);
                questionBoxes.Add(questionBox);   
            }

            pnlMain.Controls.AddRange(questionBoxes.ToArray());

            if (type == QuizViewType.take) {
                submitButton = new Button();
                submitButton.Text = "Submit";
                submitButton.BackColor = Color.FromArgb(0x00, 0x00, 0x00);
                submitButton.Font = new Font("Lucida Console", 14, FontStyle.Bold);
                submitButton.TextAlign = ContentAlignment.MiddleCenter;
                submitButton.FlatStyle = FlatStyle.Popup;
                submitButton.ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                pnlMain.Controls.Add(submitButton);
            }


            
            this.pnlMain_Resize(null, null);
        }

        private class QuestionBox : Panel
        {
            Control lblQuestion;
            Label lblHeader;
            RadioButton[] rbtnAnswers;

            QuizViewType __type;

            public QuestionBox(QuestionData question, int number, QuizViewType type)  {
                
                //
                // rbtnAnswers
                //
                __type = type;

                rbtnAnswers = new RadioButton[question.Answers.Count];
                for (int i = question.Answers.Count - 1; i >= 0; i--)
                {
                    rbtnAnswers[i] = new RadioButton();
                    rbtnAnswers[i].Text = question.Answers[i].Text;
                    rbtnAnswers[i].Dock = DockStyle.Top;
                    rbtnAnswers[i].Padding = new Padding(15, 3, 3, 3);
                    Controls.Add(rbtnAnswers[i]);

                }

                if (__type == QuizViewType.take) {
                    lblQuestion = new Label();
                }
                else {
                    lblQuestion = new TextBox();
                }
                //
                // lblQuestion
                //
                
                lblQuestion.Text = question.Text;
                lblQuestion.Dock = DockStyle.Top;
                lblQuestion.Padding = new Padding(10, 3, 3, 3);
                Controls.Add(lblQuestion);
                //
                // lblHeader
                //
                lblHeader = new Label();
                lblHeader.Text = "#" + number;
                lblHeader.TextAlign = ContentAlignment.MiddleLeft;
                lblHeader.Font = new Font("Lucida Handwriting", 24, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                lblHeader.Dock = DockStyle.Top;
                lblHeader.Height = 32;
                lblHeader.BackColor = Color.FromArgb(0x99, 0x00, 0x33);
                lblHeader.ForeColor = Color.White;
                Controls.Add(lblHeader);
                //
                // QuestionBox
                //
                this.Height = rbtnAnswers[rbtnAnswers.GetLength(0) - 1].Bottom;
                this.BackColor = Color.White;
                this.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void pnlMain_Resize(object sender, EventArgs e)
        {
            for (int i = 0; i < questionBoxes.Count; i++)
            {
                
                questionBoxes[i].Width = this.Width - 35;
                questionBoxes[i].Left = (Width - questionBoxes[i].Width) / 2;
                if (i == 0)
                {
                    questionBoxes[i].Top = 20;
                }
                else
                {
                    questionBoxes[i].Top = questionBoxes[i - 1].Bottom + 20;
                }

            }

            if (__type == QuizViewType.take) {
                submitButton.Height = 50;
                submitButton.Width = 100;
                submitButton.Location = new Point((pnlMain.Right + pnlMain.AutoScrollOffset.X) - 120, (pnlMain.Bottom + pnlMain.AutoScrollOffset.Y) - 120);
            }
        }
    }
}
