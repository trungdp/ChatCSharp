using ChatRealTime.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRealTime.DAO
{
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

        public bool invalidUser(string userName, string pass)
        {
            string query = "USP_IsInvalidAccount @UserName , @pass ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { userName, pass });
            return data.Rows.Count > 0;
        }

        public void addUser(string userName, string pass)
        {
            string query = "USP_AddAccount @UserName , @pass ";
            DataProvider.Instance.ExcuteNunQuery(query, new object[] { userName, pass});
        }

        public void updateCurrentUser(string userName)
        {
            string query = "USP_UpdateCurrentUser @name ";
            DataProvider.Instance.ExcuteNunQuery(query, new object[] { userName });
        }

        public void deleteCurrentUser()
        {
            string query = "USP_DeleteCurrentUser ";
            DataProvider.Instance.ExcuteNunQuery(query, new object[] { });
        }

        public string getCurrentUser()
        {
            string query = "USP_GetCurrentUser ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { });
            if (data.Rows.Count > 0) {
                return data.Rows[0]["userName"].ToString();
            }
            return "";
        }
    }
}