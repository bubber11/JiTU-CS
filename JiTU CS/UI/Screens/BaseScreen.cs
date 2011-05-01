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
        public void DisplayView(Views.BaseView view)
        {
            //remove all user controls
            for (int i = this.scMain.Panel2.Controls.Count - 1; i >= 0; i--)
            {
                this.scMain.Panel2.Controls[i].Dispose() ;
            }

            //show the view
            view.Dock = DockStyle.Fill;
            this.scMain.Panel2.Controls.Add(view);
            
        }
    }
}
