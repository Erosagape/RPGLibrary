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
        ArmorData armor = null;
        public ArmorData Armor
        {
            get { return armor; }
            set { armor = value; }
        }
        public FormArmorDetails()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormArmorDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormArmorDetails_FormClosing);
            btnMoveAllowed.Click += new EventHandler(btnMoveAllowed_Click);
            btnRemoveAllowed.Click += new EventHandler(btnRemoveAllowed_Click);
            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void btnRemoveAllowed_Click(object sender, EventArgs e)
        {
            if (lbAllowedClasses.SelectedItem != null)
            {
                lbClasses.Items.Add(lbAllowedClasses.SelectedItem);
                lbAllowedClasses.Items.RemoveAt(lbAllowedClasses.SelectedIndex);
            }
        }

        private void btnMoveAllowed_Click(object sender, EventArgs e)
        {
            if (lbClasses.SelectedItem != null)
            {
                lbAllowedClasses.Items.Add(lbClasses.SelectedItem);
                lbClasses.Items.RemoveAt(lbClasses.SelectedIndex);
            }
        }

        private void FormArmorDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            armor = null;
            this.FormClosing -= FormArmorDetails_FormClosing;
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            int price = 0;
            float weight = 0f;
            int defVal = 0;
            int defMod = 0;
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a name for the item.");
                return;
            }
            if(!int.TryParse(mtbPrice.Text,out price))
            {
                MessageBox.Show("Price must be an integer value.");
                return;
            }
            weight = (float)nudWeight.Value;
            if(!int.TryParse(mtbDefenseValue.Text,out defVal))
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

            armor = new ArmorData();
            armor.Name = tbName.Text;
            armor.Type = tbType.Text;
            armor.Price = price;
            armor.Weight = weight;
            armor.ArmorLocation = (ArmorLocation)cboArmorLocation.SelectedIndex;
            armor.DefenseValue = defVal;
            armor.DefenseModifier = defMod;
            armor.AllowableClasses = allowedClasses.ToArray();
            this.FormClosing -= FormArmorDetails_FormClosing;
            this.Close();
        }

        private void FormArmorDetails_Load(object sender, EventArgs e)
        {
            foreach (string s in FormDetails.EntityDataManager.EntityData.Keys)
                lbClasses.Items.Add(s);
            foreach (ArmorLocation location in Enum.GetValues(typeof(ArmorLocation)))
                cboArmorLocation.Items.Add(location);
            cboArmorLocation.SelectedIndex = 0;
            if (armor != null)
            {
                tbName.Text = armor.Name;
                tbType.Text = armor.Type;
                mtbPrice.Text = armor.Price.ToString();
                nudWeight.Value = (decimal)armor.Weight;
                cboArmorLocation.SelectedIndex = (int)armor.ArmorLocation;
                mtbDefenseValue.Text = armor.DefenseValue.ToString();
                mtbDefenseModifier.Text = armor.DefenseModifier.ToString();
                foreach(string s in armor.AllowableClasses)
                {
                    if (lbClasses.Items.Contains(s))
                        lbClasses.Items.Remove(s);
                    lbAllowedClasses.Items.Add(s);
                }
            }
        }
    }
}
