﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    /// <summary>
    /// Class Disconnect cho phép chọn và ngắt kết nối một hoặc nhiều client.
    /// </summary>
    public partial class Disconnect : Form
    {
        public List<string> inputList = new List<string>();
        public List<string> outputList = new List<string>();

        public Disconnect()
        {
            InitializeComponent();
        }

        public Disconnect(List<string> input)
        {
            InitializeComponent();
            inputList = input;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            foreach (var itemChecked in clbxClient.CheckedItems)
            {
                outputList.Add(itemChecked.ToString());
            }
            this.Close();
        }
        private void addItem()
        {
            foreach (string item in inputList)
            {
                clbxClient.Items.Add(item);
            }
        }

        private void Disconnect_Shown(object sender, EventArgs e)
        {
            addItem();
        }
    }

}
