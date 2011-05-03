using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JiTU_CS.Entity;

using JiTU_CS.Data;
using JiTU_CS.Controller;

namespace JiTU_CS.UI.Views
{
    /// <summary>
    /// allows the user to view a quiz in different formats specified by objective
    /// </summary>
    public partial class QuizView : BaseView
    {
        #region Members
        private List<QuestionBox> questionBoxes;
        private List<QuestionData> questionsToDeleteOnSave;
        private Button btnSubmit;
        private Button btnAddQuestion;
        #endregion

        #region Constructor
        public QuizView(Objective objective) : base(objective) {

            InitializeComponent();
            questionsToDeleteOnSave = new List<QuestionData>();

            //set title
            lblMessage.Text = GlobalData.currentQuiz.Name;

            QuestionEntity temp = new QuestionEntity();
            GlobalData.currentQuiz.Questions.AddRange(temp.ReadQuestions(GlobalData.currentQuiz));

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
                BackToolStripMenuItem.Visible = false;
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
                this.btnSubmit.Name = "btnSubmit";
                this.btnSubmit.UseVisualStyleBackColor = true;
                this.btnSubmit.Text = "Submit";
                this.btnSubmit.Width = 100;
                this.btnSubmit.Click += new EventHandler(btnSubmit_Click);
                pnlMain.Controls.Add(btnSubmit);
            }
            #endregion
            #region View All Results
            else if (myObjective == Objective.ViewAllResults)
            {
                saveToolStripMenuItem.Visible = false;
                discardToolStripMenuItem.Visible = false;

            }
            #endregion

            //finish up by installing resize handler
            this.pnlMain.Resize += new System.EventHandler(this.pnlMain_Resize);
        }
        #endregion

        #region Methods
        /// <summary>
        /// handles submit buttons click event.
        /// Allows student to submit a quiz they are taking.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnSubmit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to submit this quiz?", "Submit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    ResultData temp = new ResultData(GlobalData.currentUser, GlobalData.currentQuiz);
                    foreach (QuestionBox ind in questionBoxes) {
                    for (int i = 0; i < ind.rbtnAnswers.Length; i++) 
                    {
                        if (ind.rbtnAnswers[i].Checked)
                            temp.Answers.Add((AnswerData)ind.rbtnAnswers[i].Tag);
                    }
                }
                ResultsEntity res = new ResultsEntity();
                res.AddResult(temp);
                res.Dispose();

                MessageBox.Show ("You scored " + ResultsController.GetStudentPercentage(GlobalData.currentUser, GlobalData.currentQuiz) + "%");
                GoBackToQuizzesView();
            }



        }

        void btnAddQuestion_Click(object sender, EventArgs e)
        {
            QuestionData newQuestion = new QuestionData(0);
            frmQuestion questionForm = new frmQuestion(newQuestion);
            questionForm.ShowDialog();

            //check to see the question is valid ie user didnt cancel
            if (newQuestion.Answers.Count > 0)
            {
                //add question to display
                QuestionBox questionBox = new QuestionBox(newQuestion, questionBoxes.Count + 1, myObjective);
                questionBox.Disposed += new EventHandler(questionBox_Disposed);
                questionBoxes.Add(questionBox);
                pnlMain.Controls.Add(questionBox);

                //add question to currentQuiz we are editing
                GlobalData.currentQuiz.addQuestion(newQuestion);

                //set locations via resize
                pnlMain_Resize(null, null);

                pnlMain.ScrollControlIntoView(questionBox);
            }

        }

        void questionBox_Disposed(object sender, EventArgs e)
        {
            QuestionBox questionBoxDeleted = ((QuestionBox)sender);
            //remove UI element
            questionBoxes.Remove(questionBoxDeleted);
            //adding it to list to be deleted on save
            if (questionBoxDeleted.Question.Id > 0)
                questionsToDeleteOnSave.Add(questionBoxDeleted.Question);
            //reposition objects on view
            pnlMain_Resize(null, null);
        }

        public void pnlMain_Resize(object sender, EventArgs e)
        {
            //set locations of question boxes
            for (int i = 0; i < questionBoxes.Count; i++)
            {
                questionBoxes[i].Number = i + 1;
                questionBoxes[i].Width = this.Width - 40;
                questionBoxes[i].Left =  (Width - questionBoxes[i].Width) / 2 - (5);
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
                    this.btnAddQuestion.Top = questionBoxes[questionBoxes.Count - 1].Bottom + 20;
                else
                    this.btnAddQuestion.Top = 15;
                this.btnAddQuestion.Left = pnlMain.Width - btnAddQuestion.Width - 20;

                pnlMain.AutoScrollMargin = new Size(0, 20);
                pnlMain.AutoScroll = true;
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

                pnlMain.AutoScroll = true;
                pnlMain.AutoScrollMargin = new Size(0, 20);
            }
            #endregion
        }

        /// <summary>
        /// handles back button click event.
        /// Sends user back to the quizzes view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoBackToQuizzesView();
        }

        /// <summary>
        /// handles save click event.
        /// Prompts user for conformation and then saves and goes back to quizzes vies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to save changes to this quiz?", "Saving", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                //if first time were saving this quiz, we need to add it to the course as well
                bool addToCourse = (GlobalData.currentQuiz.Id == 0);

                //save it first
                QuizController.SaveQuiz(GlobalData.currentQuiz);

                //now add it to course if we determined it was first save
                if (addToCourse)
                    CourseController.AddQuiz(GlobalData.currentCourse, GlobalData.currentQuiz);

                //now delete all questions that are no longer part of this quiz
                foreach (QuestionData qDelete in questionsToDeleteOnSave)
                {
                    QuestionController.DeleteQuestion(qDelete);
                }

                //return to quizzes view
                GoBackToQuizzesView();
            }
        }

        /// <summary>
        /// handles the discard changes click event.
        /// prompt user for comformation and then discards changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void discardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to discard all changes to this quiz?", "Warning!", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                GoBackToQuizzesView();
            }
        }

        /// <summary>
        /// returns the user to the quizzes view destroying this view
        /// </summary>
        private void GoBackToQuizzesView()
        {
            GlobalData.currentQuiz = null;
            GlobalData.currentScreen.DisplayView(new QuizzesView(myObjective));
            this.Dispose();
        }

        #endregion

        #region Private Classes
        private class QuestionBox : Panel
        {
            #region Members
            private QuestionData myQuestion;
            private Control lblQuestion;
            private Label lblHeader;
            public  RadioButton[] rbtnAnswers;
            private Button btnEditQuestion;
            private Button btnDeleteQuestion;
            private Label lblResults;
            private int myNumber;
            public QuestionData Question
            {
                get
                {
                    return myQuestion;
                }
            }
            private Objective myObjective;
            #endregion

            #region Properties
            public bool IsSomethingSelected
            {
                get
                {
                    bool selected = false;
                    foreach (RadioButton rbtn in rbtnAnswers)
                    {
                        if (rbtn.Checked)
                        {
                            selected = true;
                            break;
                        }
                    }
                    return selected;
                }
            }

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
            #endregion

            #region Constructor
            public QuestionBox(QuestionData question, int number, Objective objective)
            {
                //copy question
                myQuestion = question;

                //copy objective
                myObjective = objective;

                //create default components
                InitializeComponent();

                //Create objective specific controls
                InitializeObjectiveComponent();

                //
                // QuestionBox
                //
                this.BackColor = Color.White;
                this.BorderStyle = BorderStyle.FixedSingle;
                this.Resize += new EventHandler(QuestionBox_Resize);

                //set the number
                Number = number;
            }
            #endregion

            #region Methods

            /// <summary>
            /// Handles Edit Question Button Click event
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void btnEditQuestion_Click(object sender, EventArgs e)
            {
                //display form
                frmQuestion questionForm = new frmQuestion(myQuestion);
                questionForm.ShowDialog();

                //update question box
                this.lblQuestion.Text = myQuestion.Text;
                for (int i = 0; i < myQuestion.Answers.Count; i++)
                {
                    rbtnAnswers[i].Text = myQuestion.Answers[i].Text;
                    rbtnAnswers[i].Checked = myQuestion.Answers[i].Correct;
                }

            }

            /// <summary>
            /// draws default components
            /// </summary>
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
                
            }

            /// <summary>
            /// draws application specific components
            /// </summary>
            void InitializeObjectiveComponent()
            {
                #region Edit Quiz
                if (myObjective == Objective.ManageQuizzes)
                {
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
                            rbtnAnswers[i].Top = rbtnAnswers[i - 1].Bottom + 5;

                        rbtnAnswers[i].Padding = new Padding(15, 3, 3, 3);
                        rbtnAnswers[i].Checked = myQuestion.Answers[i].Correct;
                        rbtnAnswers[i].Enabled = false;
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
                    this.btnEditQuestion.Click += new EventHandler(btnEditQuestion_Click);
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
                #region Take Quiz
                else if (myObjective == Objective.TakeQuiz)
                {
                    //
                    // rbtnAnswers
                    //
                    rbtnAnswers = new RadioButton[myQuestion.Answers.Count];
                    for (int i = 0; i < myQuestion.Answers.Count; i++)
                    {
                        rbtnAnswers[i] = new RadioButton();
                        rbtnAnswers[i].Tag = myQuestion.Answers[i];
                        rbtnAnswers[i].Text = myQuestion.Answers[i].Text;
                        if (i == 0)
                            rbtnAnswers[i].Top = lblQuestion.Bottom + 5;
                        else
                            rbtnAnswers[i].Top = rbtnAnswers[i - 1].Bottom + 5;

                        rbtnAnswers[i].Padding = new Padding(15, 3, 3, 3);
                        Controls.Add(rbtnAnswers[i]);
                    }
                }
                #endregion
                #region View All Results
                else if (myObjective == Objective.ViewAllResults)
                {
                    //get statistics
                    int numCorrect = ResultsController.GetCorrectCount(myQuestion);
                    int numWrong =  ResultsController.GetWrongCount(myQuestion);
                    int total = numCorrect + numWrong;
                    double percent = numCorrect / total;

                    //display statistics
                    lblResults = new Label();
                    lblResults.Text = percent.ToString("0.0%") + " of " + total.ToString() + " have gotten this question correct.";
                    lblResults.TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblResults);
                }
                #endregion
            }

            /// <summary>
            /// Handles delete button click event.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void btnDeleteQuestion_Click(object sender, EventArgs e)
            {
                QuestionBox questionBoxToDelete = (QuestionBox)((((Button)sender).Parent.Parent));
                questionBoxToDelete.Dispose();

            }

            /// <summary>
            /// Handles resize event of the questionbox
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void QuestionBox_Resize(object sender, EventArgs e)
            {
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

                    if (rbtnAnswers.GetLength(0) > 0)
                        this.Height = rbtnAnswers[rbtnAnswers.GetLength(0) - 1].Bottom;
                }
                #endregion
                #region Take Quiz
                if (myObjective == Objective.TakeQuiz)
                {
                    this.Height = rbtnAnswers[rbtnAnswers.GetLength(0) - 1].Bottom;
                }
                #endregion
                #region View All Results
                if (myObjective == Objective.ViewAllResults)
                {
                    lblResults.Top = lblQuestion.Bottom + 5;
                }
                #endregion

            }
            #endregion
        }
        #endregion


    }
}
