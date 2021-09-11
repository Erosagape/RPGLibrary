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
    public partial class FormShieldDetails : Form
    {
        Shield shield;
        public Shield Shield
        {
            get { return shield; }
            set { shield = value; }
        }
        public FormShieldDetails()
        {
            InitializeComponent();
            this.Load += FormShieldDetails_Load;
            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormShieldDetails_Load(object sender, EventArgs e)
        {
            
        }
    }
}
