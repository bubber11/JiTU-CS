using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JiTU_CS.UI
{
    public partial class frmUser : Form
    {
        Data.UserData externalUser;

        public frmUser(Data.UserData user)
        {
            externalUser = user;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                MessageBox.Show("Passwords do not match!");
            }
            else
            {
                //if we arent updating, create
                if (externalUser == null)
                {
                    externalUser = new JiTU_CS.Data.UserData();
                }

                //copy values
                externalUser.FullName = txtFullName.Text;
                externalUser.UserName = txtUserName.Text;
                externalUser.Password = txtPassword.Text;
                
                //save user to database
                Controller.UserController.SaveUser(externalUser);

            }

			this.Close();
            
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            if (externalUser != null)
            {
                txtFullName.Text = externalUser.FullName;
                txtUserName.Text = externalUser.UserName;
                txtPassword.Text = externalUser.Password;
                txtPasswordConfirm.Text = externalUser.Password;
            }
        }

    }
}
