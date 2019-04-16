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
        internal UserStatus Status {
            get{
                return this.status;
            }
            set{
                this.status = value;
            }
        }
        public string Pass {
            get
            {
                return this.pass;
            }
            set
            {
                this.pass = value;
            }
        }

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
            this.Pass = row["pass"].ToString();
            this.Status = (UserStatus)row["status"];
        }
    }
}
