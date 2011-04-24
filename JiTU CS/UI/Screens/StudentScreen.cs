using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JiTU_CS.UI.Screens
{
    public partial class StudentScreen : UserScreen
    {
        public StudentScreen()
        {
            InitializeComponent();
        }

        public StudentScreen(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
