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
        /// <summary>
        /// sự kiện click vào btnLogin_Click nếu có lỗi thì in lỗi ra ở lblError,
        /// nếu không có lỗi thì mở form ChatDetail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(checkError())){
                lblError.Text = checkError();
            } else
            {
                this.Hide();
                ChatDetail clientForm = new ChatDetail();
                clientForm.setName(tbxName.Text);
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
        /// <summary>
        /// hàm checkError trả về một string hoặc null,
        /// nếu ô tên đăng nhập trống thì trả về lỗi String.IsNullOrEmpty(name),
        /// nếu ô mật khẩu trống trả về lỗi String.IsNullOrEmpty(pass),
        /// nếu ô tên đăng nhập hoặc mật khẩu không đúng trả về lỗi UserStore.Instance.invalidUser(name,pass).
        /// </summary>
        /// <returns></returns>
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
