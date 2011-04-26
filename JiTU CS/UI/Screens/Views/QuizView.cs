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

namespace JiTU_CS.UI.Screens.Views
{
    public partial class QuizView : BaseView
    {
        public QuizView(QuizData quiz)
        {
            InitializeComponent();
            lblMessage.Text = quiz.Name;

            QuizController.GetQuestions(quiz);
            
        }
    }
}
