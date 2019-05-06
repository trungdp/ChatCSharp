using ChatRealTime.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        #region EVENT
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(checkError())){
                lblError.Text = checkError();
            } else
            {
                this.Hide();
                ChatDetail clientForm = new ChatDetail();
                clientForm.name = tbxName.Text;
                clientForm.ShowDialog();
                this.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            SignUp signupForm = new SignUp();
            this.Hide();
            signupForm.ShowDialog();
            this.Show();
            tbxName.Text = "";
            tbxPassword.Text = "";
        }
        #endregion

        #region UTILS
        private string checkError()
        {
            string name = tbxName.Text;
            string pass = tbxPassword.Text;
            if (String.IsNullOrEmpty(name))
            {
                return "Tên đăng nhập không được để trống!";
            }
            else if (String.IsNullOrEmpty(pass))
            {
                return "Mật khẩu không được để trống!";
            }
            else if(!UserStore.Instance.invalidUser(name,pass)) {
                return "Tên đăng nhập hoặc mật khẩu không đúng!";
            }
            return null;
        }
        #endregion

    }
}
