using ChatRealTime.DTO;
using Server.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DAO
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

        public void addMessage(string userName, string message, string sender)
        {
            string query = "USP_AddMessage @name , @message , @sender ";
            DataProvider.Instance.ExcuteNunQuery(query, new object[] { userName, message,sender });
        }

        public void deleteMessage(string userName)
        {
            string query = "USP_DeleteMessage @name";
            DataProvider.Instance.ExcuteNunQuery(query, new object[] { userName });
        }

        public List<MessageOffline> getMessageByName(string name)
        {
            string query = "USP_GetMessage @name";
            List<MessageOffline> result = new List<MessageOffline>();
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { name});
            foreach (DataRow row in data.Rows) {
                result.Add(new MessageOffline(row));
            }
            return result;
        }
    }
}
