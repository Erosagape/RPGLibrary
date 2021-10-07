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
        ShieldData shield;
        public ShieldData Shield
        {
            get { return shield; }
            set { shield = value; }
        }
        public FormShieldDetails()
        {
            InitializeComponent();
            this.Load += FormShieldDetails_Load;
            this.FormClosing += FormShieldDetails_FormClosing;
            btnMoveAllowed.Click += BtnMoveAllowed_Click;
            btnRemoveAllowed.Click += BtnRemoveAllowed_Click;
            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnRemoveAllowed_Click(object sender, EventArgs e)
        {
            if (lbAllowedClasses.SelectedItem != null)
            {
                lbClasses.Items.Add(lbAllowedClasses.SelectedItem);
                lbAllowedClasses.Items.RemoveAt(lbAllowedClasses.SelectedIndex);
            }
        }

        private void BtnMoveAllowed_Click(object sender, EventArgs e)
        {
            if (lbClasses.SelectedItem != null)
            {
                lbAllowedClasses.Items.Add(lbClasses.SelectedItem);
                lbClasses.Items.RemoveAt(lbClasses.SelectedIndex);
            }
        }

        private void FormShieldDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            shield = null;
            this.FormClosing -= FormShieldDetails_FormClosing;
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            int price = 0;
            float weight =0f;
            int defVal = 0;
            int defMod = 0;
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a name for the item.");
                return;
            }
            if (!int.TryParse(mtbPrice.Text, out price))
            {
                MessageBox.Show("Price must be an integer value.");
                return;
            }
            weight = (float)nudWeight.Value;
            if (!int.TryParse(mtbDefenseValue.Text, out defVal))
            {
                MessageBox.Show("Defense value must be an integer value.");
                return;
            }
            if (!int.TryParse(mtbDefenseModifier.Text, out defMod))
            {
                MessageBox.Show("Defense modifier must be an integer value.");
                return;
            }
            List<string> allowedClasses = new List<string>();
            foreach (object o in lbAllowedClasses.Items)
                allowedClasses.Add(o.ToString());
            shield = new ShieldData();
            shield.Name = tbName.Text;
            shield.Type = tbType.Text;
            shield.Price = price;
            shield.Weight = weight;
            shield.DefenseValue = defVal;
            shield.DefenseModifier = defMod;
            shield.AllowableClasses = allowedClasses.ToArray();
            this.FormClosing -= FormShieldDetails_FormClosing;
            this.Close();
        }

        private void FormShieldDetails_Load(object sender, EventArgs e)
        {
            foreach (string s in FormDetails.EntityDataManager.EntityData.Keys)
                lbClasses.Items.Add(s);
            if (shield != null)
            {
                tbName.Text = shield.Name;
                tbType.Text = shield.Type;
                mtbPrice.Text = shield.Price.ToString();
                nudWeight.Value = (decimal)shield.Weight;
                mtbDefenseValue.Text = shield.DefenseValue.ToString();
                mtbDefenseModifier.Text = shield.DefenseModifier.ToString();
                foreach(string s in shield.AllowableClasses)
                {
                    if (lbClasses.Items.Contains(s))
                        lbClasses.Items.Remove(s);
                    lbAllowedClasses.Items.Add(s);
                }
            }
        }
    }
}
