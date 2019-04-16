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

        public int ID { 
            get{
                return this.iD;
            }
            set{
                this.iD = value;
            }
        }
        public string Name {
            get{
                return this.name;
            }
            set{
                this.name = value;
            }
        }
        public List<int> UserIDs { 
            get{
                return this.userIDs;
            }
            set{
                this.userIDs = value;
            }
        }
        public List<int> Messages {
            get
            {
                return this.messages;
            }
            set
            {
                this.messages = value;
            }
        }
    }
}
