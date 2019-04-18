using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    interface IMessage
    {
        int ID
        {
            get;
            set;
        }
        object Content
        {
            get;
            set;
        }
        int SendAt
        {
            get;
            set;
        }
        int IDSender
        {
            get;
            set;
        }
    }
}
