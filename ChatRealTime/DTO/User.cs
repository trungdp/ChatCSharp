using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRealTime.DTO
{
    enum UserStatus
    {
        ONLINE = 0,
        OFFLINE = 1
    }
    class User
    {

        private int iD;
        private string name;
        private string pass;
        private UserStatus status;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        internal UserStatus Status { get => status; set => status = value; }
        public string Pass { get => pass; set => pass = value; }

        public User(int id, string name,string pass, UserStatus status)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
            this.Pass = pass;
        }

        public User(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.pass = row["pass"].ToString();
            this.Status = (UserStatus)row["status"];
        }
    }
}
