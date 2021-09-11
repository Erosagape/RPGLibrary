using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RpgEditor
{
    public partial class FormWeapon : FormDetails
    {
        public FormWeapon()
        {
            InitializeComponent();
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
        }
        public void FillListBox()
        {
            lbDetails.Items.Clear();
            foreach (string s in FormDetails.ItemManager.WeaponData.Keys)
                lbDetails.Items.Add(FormDetails.ItemManager.WeaponData[s]);
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

    }
}
