using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DTO
{
    class MessageOffline
    {
        private string name;
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

        public MessageOffline() { }

        public MessageOffline(DataRow row)
        {
            this.name = row["userName"].ToString();
            this.name = row["message"].ToString();
        }
    }
}
