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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        #region EVENT
        /// <summary>
        ///  /// sự kiện click vào btnLogin_Click nếu có lỗi thì in lỗi ra ở lblError,
        /// nếu không có lỗi thì thêm user vào database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(checkError()))
            {
                lblError.Text = checkError();
            } else
            {
                UserStore.Instance.addUser(tbxName.Text, tbxPassword.Text);
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region UTILS
        private string checkError()
        {
            string name = tbxName.Text;
            string pass = tbxPassword.Text;
            string confirm = tbxConfirm.Text;
            if (String.IsNullOrEmpty(name))
            {
                return "Tên đăng nhập không được để trống!";
            }
            else if (String.IsNullOrEmpty(pass))
            {
                return "Mật khẩu không được để trống!";
            }
            else if (confirm != pass)
            {
                return "Xác nhận mật khẩu không trùng khớp!";
            }
            return null;
        }
        #endregion
        
    }
}
