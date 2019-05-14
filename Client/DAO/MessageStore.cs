using ChatRealTime.DTO;
using Client.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DAO
{
    class MessageStore
    {
        private static MessageStore instance;

        internal static MessageStore Instance
        {
            get {
                if (instance == null)
                    instance = new MessageStore();
                return instance;
            }

            set {
                instance = value;
            }
        }

        private MessageStore() { }

        public void addMessage(string userName, string message)
        {
            string query = "USP_AddMessage @name , @pass ";
            DataProvider.Instance.ExcuteNunQuery(query, new object[] { userName, message });
        }

        public List<MessageOffline> getAllUserName(string name)
        {
            string query = "USP_GetMessage @name";
            List<MessageOffline> result = new List<MessageOffline>();
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { name });
            foreach (DataRow row in data.Rows) {
                result.Add(new MessageOffline(row));
            }
            return result;
        }
    }
}
