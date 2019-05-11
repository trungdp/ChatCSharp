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
            DataProvider.Instance.ExcuteNunQuery(query, new object[] { userName, pass });
        }

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