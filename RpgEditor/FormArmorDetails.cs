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
    public partial class FormArmorDetails : Form
    {
        Armor armor = null;
        public Armor Armor
        {
            get { return armor; }
            set { armor = value; }
        }
        public FormArmorDetails()
        {
            InitializeComponent();
            this.Load += FormArmorDetails_Load;
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

        private void FormArmorDetails_Load(object sender, EventArgs e)
        {
            
        }
    }
}
