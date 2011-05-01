using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using JiTU_CS.Data;
using JiTU_CS.Controller;

namespace JiTU_CS.UI
{
    public partial class frmSubmit : Form
    {
        QuizData myQuiz; //quiz we are submitting

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="quiz"></param>
        public frmSubmit(QuizData quiz)
        {
            InitializeComponent();

            myQuiz = quiz;

            this.Text = "Submitting " + myQuiz.Name;
        }

        /// <summary>
        /// Handles cancel button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// handles submit button's click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //make sure user knows what they are doing
            var result = MessageBox.Show("Are you sure you want to submit this quiz? It will no longer be editable."
                , "Warning!", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                myQuiz.Open = dtpOpen.Value;
                myQuiz.Due = dtpClose.Value;

                try
                {
                    //try to submit and exit
                    QuizController.SubmitQuiz(myQuiz);
                    this.Dispose();
                }
                catch (Exception exception)
                {
                    //show error
                    MessageBox.Show(exception.Message);
                    //reset dates
                    myQuiz.Open = DateTime.MinValue;
                    myQuiz.Due = DateTime.MinValue;
                }
            }
        }
    }
}
