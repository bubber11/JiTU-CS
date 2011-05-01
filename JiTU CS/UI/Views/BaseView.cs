using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JiTU_CS.UI.Views
{
    public enum Objective {ManageStudents, ManageCourses, ManageQuizzes, ViewAllResults, TakeQuiz, ViewSingleResults};

    /// <summary>
    /// Creates a default view, other views inherit this one
    /// </summary>
    ///
    public partial class BaseView : UserControl
    {
        protected Objective myObjective;

        /// <summary>
        /// gets the objective of the view
        /// </summary>
        public Objective Objective
        {
            get
            {
                return myObjective;
            }
        }

        /// <summary>
        /// default contructor, no objective
        /// </summary>
        public BaseView()
        {
            //draw components
            InitializeComponent();
        }

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
