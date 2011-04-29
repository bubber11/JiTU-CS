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
    public enum ViewTypes { Quizzes, Students };

    public partial class BaseView : UserControl
    {
        public BaseView()
        {
            InitializeComponent();
        }
    }
}
