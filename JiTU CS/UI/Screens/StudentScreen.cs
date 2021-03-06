﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using JiTU_CS.UI.Views;

namespace JiTU_CS.UI.Screens
{
    public partial class StudentScreen : BaseScreen
    {
        public StudentScreen()
        {
            InitializeComponent();
        }

        private void StudentScreen_Load(object sender, EventArgs e)
        {
            DisplayView(new Views.WelcomeView());
        }

        private void btnTakeQuiz_Click(object sender, EventArgs e)
        {
            DisplayView(new Views.ClassesView(Objective.TakeQuiz, "Take a quiz for which class?"));
        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
            DisplayView( new Views.ClassesView(Objective.ViewSingleResults, "View results for quiz taken in which class?"));
        }

    }
}
