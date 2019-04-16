using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRealTime.DTO
{
    class Conversation
    {
        private int iD;
        private string name;
        private List<int> userIDs;
        private List<int> messages;

        public Conversation(int iD, string name, List<int> userIDs, List<int> messages)
        {
            this.ID = iD;
            this.Name = name;
            this.UserIDs = userIDs;
            this.Messages = messages;
        }

        public Conversation(DataRow row)
        {
            List<int> userID = new List<int>();
            this.ID = (int)row["id"];
            this.Name = "Conversation";
            //this.UserIDs = Array(row[""]);
            this.Messages = messages;
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public List<int> UserIDs { get => userIDs; set => userIDs = value; }
        public List<int> Messages { get => messages; set => messages = value; }
    }
}
