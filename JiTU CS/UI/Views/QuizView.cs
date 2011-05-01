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
        private List<QuestionBox> questionBoxes;
        private Button btnSubmit;
        private Button btnAddQuestion;

        public QuizView(Objective objective) : base(objective) {

            InitializeComponent();

            //set title
            lblMessage.Text = GlobalData.currentQuiz.Name;

            //create our questions and add them
            questionBoxes = new List<QuestionBox>();
            for (int i = 0; i < GlobalData.currentQuiz.Questions.Count; i++)
            {
                QuestionBox questionBox = new QuestionBox(GlobalData.currentQuiz.Questions[i], i + 1, myObjective);
                questionBox.Disposed += new EventHandler(questionBox_Disposed);
                questionBoxes.Add(questionBox);
            }

            pnlMain.Controls.AddRange(questionBoxes.ToArray());

            //add objective specific objects
            #region Edit Quiz
            if (myObjective == Objective.ManageQuizzes)
            {
                // 
                // btnAddQuestion
                // 
                this.btnAddQuestion = new Button();
                this.btnAddQuestion.BackgroundImage = global::JiTU_CS.Properties.Resources.add_question;
                this.btnAddQuestion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                this.btnAddQuestion.Name = "btnAddQuestion";
                this.btnAddQuestion.Size = new System.Drawing.Size(32, 32);
                this.btnAddQuestion.UseVisualStyleBackColor = true;
                this.btnAddQuestion.FlatAppearance.BorderSize = 0;
                this.btnAddQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnAddQuestion.Click += new EventHandler(btnAddQuestion_Click);
                pnlMain.Controls.Add(btnAddQuestion);
            }
            #endregion
            #region Take Quiz
            else if (myObjective == Objective.TakeQuiz)
            {
                mnsMain.Visible = false;
                //
                // btnSubmit
                //
                this.btnSubmit = new Button();
                this.btnSubmit.Name = "btnAddQuestion";
                this.btnSubmit.UseVisualStyleBackColor = true;
                this.btnSubmit.Text = "Submit";
                this.btnSubmit.Width = 100;
                pnlMain.Controls.Add(btnSubmit);
            }
            #endregion

            //finish up by installing resize handler
            this.pnlMain.Resize += new System.EventHandler(this.pnlMain_Resize);
        }

        void btnAddQuestion_Click(object sender, EventArgs e)
        {
            //dummy data
            QuestionData question = new QuestionData(0);
            question.Text = "This is a question.";
            AnswerData answer = new AnswerData(0);
            answer.Text =  "Answer";
            question.AddAnswer(answer);
            question.AddAnswer(answer);
            question.AddAnswer(answer);
            question.AddAnswer(answer);

            //add question to display
            QuestionBox questionBox = new QuestionBox(question, questionBoxes.Count + 1, myObjective);
            questionBox.Disposed += new EventHandler(questionBox_Disposed);
            questionBoxes.Add(questionBox);
            pnlMain.Controls.Add(questionBox);

            //set locations via resize
            pnlMain_Resize(null, null);

            pnlMain.ScrollControlIntoView(questionBox);

        }

        void questionBox_Disposed(object sender, EventArgs e)
        {
            QuestionBox questionBoxDeleted = ((QuestionBox)sender);
            questionBoxes.Remove(questionBoxDeleted);
            pnlMain_Resize(null, null);
        }

        public void pnlMain_Resize(object sender, EventArgs e)
        {
            //set locations of question boxes
            for (int i = 0; i < questionBoxes.Count; i++)
            {
                questionBoxes[i].Number = i + 1;
                questionBoxes[i].Width = this.Width - 35;
                questionBoxes[i].Left = (Width - questionBoxes[i].Width) / 2;
                if (i == 0)
                {
                    questionBoxes[i].Top = pnlMain.AutoScrollPosition.Y + 20;
                }
                else
                {
                    questionBoxes[i].Top = questionBoxes[i - 1].Bottom + 20;
                }

            }

            //set locations for objective specific objects
            #region Edit Quiz
            if (myObjective == Objective.ManageQuizzes)
            {
                if (questionBoxes.Count != 0)
                    this.btnAddQuestion.Top = questionBoxes[questionBoxes.Count - 1].Bottom + 10;
                else
                    this.btnAddQuestion.Top = 15;
                this.btnAddQuestion.Left = pnlMain.Width - btnAddQuestion.Width - 20;
            }
            #endregion
            #region Take Quiz
            else if (myObjective == Objective.TakeQuiz)
            {
                if (questionBoxes.Count != 0)
                    this.btnSubmit.Top = questionBoxes[questionBoxes.Count - 1].Bottom + 10;
                else
                    this.btnSubmit.Top = 15;
                this.btnSubmit.Left = pnlMain.Width - btnSubmit.Width - 20;
            }
            #endregion
        }

        private class QuestionBox : Panel
        {
            private QuestionData myQuestion;
            private Control lblQuestion;
            private Label lblHeader;
            private RadioButton[] rbtnAnswers;
            private Button btnEditQuestion;
            private Button btnDeleteQuestion;

            private int myNumber;

            private Objective myObjective;

            public int Number
            {
                get
                {
                    return myNumber;
                }
                set
                {
                    myNumber = value;
                    lblHeader.Text = "#" + myNumber;
                }
            }

            public QuestionBox(QuestionData question, int number, Objective objective)
            {
                //copy question
                myQuestion = question;

                //copy objective
                myObjective = objective;

                //create default components
                InitializeComponent();

                //Create objective specific controls
                #region Edit Quiz
                if (myObjective == Objective.ManageQuizzes)
                {
                    //edit radio buttons
                    for (int i = 0; i < myQuestion.Answers.Count; i++)
                    {
                        if (myQuestion.Answers[i].Correct)
                            rbtnAnswers[i].Checked = true;
                        rbtnAnswers[i].Enabled = false;

                        rbtnAnswers[i].Padding = new Padding(15, 3, 3, 3);
                        Controls.Add(rbtnAnswers[i]);
                    }
                    // 
                    // btnEditQuestion
                    // 
                    this.btnEditQuestion = new Button();
                    this.btnEditQuestion.BackgroundImage = global::JiTU_CS.Properties.Resources.edit_question;
                    this.btnEditQuestion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    this.btnEditQuestion.Name = "btnEditQuestion";
                    this.btnEditQuestion.Size = new System.Drawing.Size(24, 24);
                    this.btnEditQuestion.UseVisualStyleBackColor = true;
                    this.btnEditQuestion.FlatAppearance.BorderSize = 0;
                    this.btnEditQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    this.lblHeader.Controls.Add(btnEditQuestion);
                    // 
                    // btnDeleteQuestion
                    // 
                    this.btnDeleteQuestion = new Button();
                    this.btnDeleteQuestion.BackgroundImage = global::JiTU_CS.Properties.Resources.remove_question;
                    this.btnDeleteQuestion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    this.btnDeleteQuestion.Name = "btnAddQuestion";
                    this.btnDeleteQuestion.Size = new System.Drawing.Size(24, 24);
                    this.btnDeleteQuestion.UseVisualStyleBackColor = true;
                    this.btnDeleteQuestion.FlatAppearance.BorderSize = 0;
                    this.btnDeleteQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    this.lblHeader.Controls.Add(btnDeleteQuestion);
                    this.btnDeleteQuestion.Click += new EventHandler(btnDeleteQuestion_Click);
                }
                #endregion

                //
                // QuestionBox
                //
                this.Height = rbtnAnswers[rbtnAnswers.GetLength(0) - 1].Bottom;
                this.BackColor = Color.White;
                this.BorderStyle = BorderStyle.FixedSingle;
                this.Resize += new EventHandler(QuestionBox_Resize);

                //set the number
                Number = number;
            }

            void InitializeComponent()
            {
                //
                // lblHeader
                //
                lblHeader = new Label();
                lblHeader.TextAlign = ContentAlignment.MiddleLeft;
                lblHeader.Font = new Font("Lucida Handwriting", 24, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                lblHeader.Top = 0;
                lblHeader.Left = 0;
                lblHeader.Height = 32;
                lblHeader.BackColor = Color.FromArgb(0x99, 0x00, 0x33);
                lblHeader.ForeColor = Color.White;
                Controls.Add(lblHeader);
                //
                // lblQuestion
                //
                lblQuestion = new Label();
                lblQuestion.Text = myQuestion.Text;
                lblQuestion.Top = lblHeader.Bottom + 5;
                lblQuestion.Left = 0;
                lblQuestion.Padding = new Padding(10, 3, 3, 3);
                Controls.Add(lblQuestion);
                //
                // rbtnAnswers
                //
                rbtnAnswers = new RadioButton[myQuestion.Answers.Count];
                for (int i = 0; i < myQuestion.Answers.Count; i++)
                {
                    rbtnAnswers[i] = new RadioButton();

                    rbtnAnswers[i].Text = myQuestion.Answers[i].Text;
                    if (i == 0)
                        rbtnAnswers[i].Top = lblQuestion.Bottom + 5;
                    else
                        rbtnAnswers[i].Top = rbtnAnswers[i-1].Bottom + 5;

                    rbtnAnswers[i].Padding = new Padding(15, 3, 3, 3);
                    Controls.Add(rbtnAnswers[i]);
                }
                
            }

            void btnDeleteQuestion_Click(object sender, EventArgs e)
            {
                QuestionBox questionBoxToDelete = (QuestionBox)((((Button)sender).Parent.Parent));
                questionBoxToDelete.Dispose();

            }

            void QuestionBox_Resize(object sender, EventArgs e)
            {
                SuspendLayout();

                //resize default controls
                foreach (Control control in this.Controls)
                {
                    if (control.GetType() == typeof(RadioButton))
                        control.Width = this.Width;
                    if (control.GetType() == typeof(Label))
                        control.Width = this.Width;
                }

                //resize objective specific controls
                #region Edit Quiz
                if (myObjective == Objective.ManageQuizzes)
                {
                    this.btnDeleteQuestion.Top = 4;
                    this.btnDeleteQuestion.Left = lblHeader.Width - btnDeleteQuestion.Width - 4;
                    this.btnEditQuestion.Top = 4;
                    this.btnEditQuestion.Left = btnDeleteQuestion.Left - btnEditQuestion.Width - 4;
                }
                #endregion

                ResumeLayout();
            }
        }
    }
}
