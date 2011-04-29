﻿using System;
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
        public QuizView()
        {
            InitializeComponent();
            //set title
            lblMessage.Text = GlobalData.currentQuiz.Name;

            //get questions, and display them
            QuizController.GetQuestions(GlobalData.currentQuiz);

            for (int i = GlobalData.currentQuiz.Questions.Count - 1; i >= 0; i--)
            {
                QuestionBox questionBox = new QuestionBox(GlobalData.currentQuiz.Questions[i], i + 1);
                questionBox.Dock = DockStyle.Top;
                pnlMain.Controls.Add(questionBox);
            }
            

            
        }

        private class QuestionBox : Panel
        {
            Label lblQuestion;
            Label lblHeader;
            RadioButton[] rbtnAnswers;

            public QuestionBox(QuestionData question, int number)
            {
                //
                // rbtnAnswers
                //
                rbtnAnswers = new RadioButton[question.Answers.Count];
                for (int i = question.Answers.Count - 1; i >= 0; i--)
                {
                    rbtnAnswers[i] = new RadioButton();
                    rbtnAnswers[i].Text = question.Answers[i].Text;
                    rbtnAnswers[i].Dock = DockStyle.Top;
                    rbtnAnswers[i].Padding = new Padding(15, 3, 3, 3);
                    Controls.Add(rbtnAnswers[i]);

                }
                //
                // lblQuestion
                //
                lblQuestion = new Label();
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
                lblHeader.BackColor = Color.Maroon;
                lblHeader.ForeColor = Color.White;
                Controls.Add(lblHeader);
                //
                // QuestionBox
                //
                this.Height = rbtnAnswers[rbtnAnswers.GetLength(0) - 1].Bottom;


            }
        }
    }
}
