using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JiTU_CS.UI.Screens
{
    public partial class BaseScreen : UserControl
    {
        public BaseScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Displays a view
        /// </summary>
        /// <param name="view">The view to show</param>
        protected void DisplayView(Views.BaseView view)
        {
            //remove all user controls
            foreach (Control oControl in this.scMain.Panel2.Controls)
                if (oControl is UserControl)
                    oControl.Dispose();

            //show the view
            view.Dock = DockStyle.Fill;
            this.scMain.Panel2.Controls.Add(view);
            
        }
    }
}
