﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArbitesR
{
    public partial class FmKeySelector : Form
    {
        public FmKeySelector()
        {
            InitializeComponent();
            foreach (ClKeyGroup kg in ClKey.lists)
            {
                var tp = new TabPage();
                tp.Text = kg.name;
                tp.BackColor = SystemColors.Control;
                tcMain.TabPages.Add(tp);
                var flp = new FlowLayoutPanel();
                flp.Dock = DockStyle.Fill;
                flp.Parent = tp;
                flp.AutoScroll = true;
                foreach (ClKey key in kg.key)
                {

                    var newb = new Button();
                    newb.Name = "bt_" + key.val + "_" + key.ktype;
                    newb.Text = key.display;
                    newb.Size = new Size(72, 72);
                    newb.Parent = flp;
                    newb.Click += new EventHandler(this.KeyBtnClicked);
                }

            }
        }

        public void KeyBtnClicked (object sender, EventArgs e)
        {
            string btn = (sender as Button).Name;
            btn = btn.Substring(btn.IndexOf("_") + 1);
            int val = Convert.ToByte(btn.Substring(0, btn.IndexOf("_")));
            btn = btn.Substring(btn.IndexOf("_") + 1);
            int ktype = Convert.ToByte(btn);
            MdGlobals.selectedKey = ClKey.dKeys.Find(k => (k.val == val && k.ktype == ktype));
            MdGlobals.selectedSpecial = true;
        }
    }
}
