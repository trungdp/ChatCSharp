using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class EmojiMenu : Form
    {
        public string result = null;
        List<string> data = new List<string>() {
            "😬","😁","😂","😃","😄","😅",
            "😆","😇","😉","😊","🙂","☺",
            "😋","😌","😍","😘","😗","😙",
            "😚","😜","😝","😛","😎","😏",
            "😶","😐","😑","😒","😳","😞",
            "😟","😠","😡","😔","😕"};
        public EmojiMenu()
        {
            InitializeComponent();

        }

        private void lvMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            result = lvMenu.SelectedItems[0].Text;
            this.Close();
        }

        private void EmojiMenu_Shown(object sender, EventArgs e)
        {
            foreach (string item in data)
            {
                lvMenu.Items.Add(item);
            }
        }
    }
}
