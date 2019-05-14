using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    class MessageOffline
    {
        private string name;
        private string sender;
        private string message;

        public string Name
        {
            get {
                return this.name;
            }
            set {
                this.name = value;
            }
        }
        internal string Message
        {
            get {
                return this.message;
            }
            set {
                this.message = value;
            }
        }

        internal string Sender
        {
            get {
                return this.sender;
            }
            set {
                this.sender = value;
            }
        }

        public MessageOffline() { }

        public MessageOffline(DataRow row)
        {
            this.Name = row["userName"].ToString();
            this.Message = row["message"].ToString();
            this.Sender = row["senderr"].ToString();
        }
    }
}
