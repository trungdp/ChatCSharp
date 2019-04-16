using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    class TextContent
    {
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public TextContent(string text)
        {
            this.text = text;
        }
    }
    class TextMessage:IMessage
    {
        private int id;
        private TextContent textContent;
        private int sendAt;
        private int idSender;

        public TextMessage(int id, string text, int sendTime, int idSender)
        {
            this.id = id;
            this.textContent = new TextContent(text);
            this.sendAt = sendTime;
            this.idSender = idSender;
        }
        public TextMessage(string text, int sendTime, int idSender)
        {
            this.textContent = new TextContent(text);
            this.sendAt = sendTime;
            this.idSender = idSender;
        }
        public int ID
        {
            get { return id;}
            set {id = value;}
        }
        public object Content
        {
            get { return textContent.Text;}
            set { textContent.Text = value as string;}
        }
        public int SendAt
        {
            get { return sendAt; }
            set { sendAt = value; }
        }
        public int IDSender
        {
            get { return idSender; }
            set { idSender = value; }
        }
    }
}
