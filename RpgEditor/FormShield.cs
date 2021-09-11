using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RpgEditor
{
    public partial class FormShield : FormDetails
    {
        public FormShield()
        {
            InitializeComponent();
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
        }
        public void FillListBox()
        {
            lbDetails.Items.Clear();
            foreach (string s in FormDetails.ItemManager.ShieldData.Keys)
                lbDetails.Items.Add(FormDetails.ItemManager.ShieldData[s]);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
