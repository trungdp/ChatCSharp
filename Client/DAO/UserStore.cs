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
            string query1 = "USP_IsInvalidAccount @UserName , @pass ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query1, new object[] { userName, pass });
            return data.Rows.Count > 0;
        }
    }
}