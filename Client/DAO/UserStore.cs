using ChatRealTime.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRealTime.DAO
{
    /// <summary>
    /// Lớp UserStore chứa những hàm để làm việc với database
    /// </summary>
    class UserStore
    {
        private static UserStore instance;

        internal static UserStore Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserStore();
                return instance;
            }

            set
            {
                instance = value;
            }
        }

        private UserStore() { }

        /// <summary>
        /// Hàm invalidUser kiểm tra user có tồn tại hay không?
        /// Nếu có trả về True, nếu không trả về False
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool invalidUser(string userName, string pass)
        {
            string query = "USP_IsInvalidAccount @UserName , @pass ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { userName, pass });
            return data.Rows.Count > 0;
        }

        /// <summary>
        /// Hàm addUser để thêm một user vào database
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pass"></param>
        public void addUser(string userName, string pass)
        {
            string query = "USP_AddAccount @UserName , @pass ";
            DataProvider.Instance.ExcuteNunQuery(query, new object[] { userName, pass});
        }
        /// <summary>
        /// Hàm getAllUserName trả về tên của tát cả các user trong database
        /// </summary>
        /// <returns></returns>
        public List<string> getAllUserName()
        {
            string query = "USP_GetAllUserName ";
            List<string> result = new List<string>();
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow row in data.Rows) {
                result.Add(row["userName"].ToString());
            }
            return result;
        }
    }
}