﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JiTU_CS.UI.Views
{
    public enum Objective {ManageStudents, ManageCourses, ManageQuizzes, ViewAllResults, TakeQuiz, ViewSingleResults, Nothing};

    /// <summary>
    /// Creates a default view, other views inherit this one
    /// </summary>
    ///
    public partial class BaseView : UserControl
    {
        protected Objective myObjective;

        /// <summary>
        /// draws default components
        /// </summary>
        /// <param name="objective">the objective of this view</param>
        public BaseView(Objective objective)
        {
            //draw components
            InitializeComponent();

            //copy obejctive
            myObjective = objective;
        }
    }
}
