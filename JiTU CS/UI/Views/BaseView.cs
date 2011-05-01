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
    public enum ViewTypes { Quizzes, Students, NoWhere };

    /// <summary>
    /// Creates a default view, other views inherit this one
    /// </summary>
    public partial class BaseView : UserControl
    {
        /// <summary>
        /// Draws default components
        /// </summary>
        public BaseView()
        {
            InitializeComponent();
        }
    }
}
