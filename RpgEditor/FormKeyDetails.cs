using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.ItemClasses;
namespace RpgEditor
{
    public partial class FormKeyDetails : Form
    {
        KeyData key;
        public KeyData Key
        {
            get { return key; }
            set { key = value; }
        }
        public FormKeyDetails()
        {
            InitializeComponent();
            this.Load += FormKeyDetails_Load;
            this.FormClosing += FormKeyDetails_FormClosing;
            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            key = null;
            this.FormClosing -= FormKeyDetails_FormClosing;
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a name for the item.");
                return;
            }
            key = new KeyData();
            key.Name = tbName.Text;
            key.Type = tbType.Text;
            this.FormClosing -= FormKeyDetails_FormClosing;
            this.Close();
        }

        private void FormKeyDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void FormKeyDetails_Load(object sender, EventArgs e)
        {
            if (key != null)
            {
                tbName.Text = key.Name;
                tbType.Text = key.Type;
            }
        }

    }
}
