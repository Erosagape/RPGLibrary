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
    public partial class FormWeaponDetails : Form
    {
        WeaponData weapon;
        public WeaponData Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }
        public FormWeaponDetails()
        {
            InitializeComponent();
            this.Load += FormWeaponDetails_Load;
            this.FormClosing += FormWeaponDetails_FormClosing;
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

        private void FormWeaponDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            weapon = null;
            this.FormClosing -= FormWeaponDetails_FormClosing;
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            int price = 0;
            float weight = 0f;
            int atkVal = 0;
            int atkMod = 0;
            int dmgVal = 0;
            int dmgMod = 0;
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a name for the item");
                return;
            }
            if(!int.TryParse(mtbPrice.Text,out price))
            {
                MessageBox.Show("Price must be an integer value");
                return;
            }
            if (!float.TryParse(nudWeight.Text, out weight))
            {
                MessageBox.Show("Weight must be an integer value");
                return;
            }
            if (!int.TryParse(mtbAttackValue.Text, out atkVal))
            {
                MessageBox.Show("Attack value must be an integer value");
                return;
            }
            if (!int.TryParse(mtbAttackModifier.Text, out atkMod))
            {
                MessageBox.Show("Attack Modifier must be an integer value");
                return;
            }
            if (!int.TryParse(mtbDamageValue.Text, out dmgVal))
            {
                MessageBox.Show("Damage value must be an integer value");
                return;
            }
            if (!int.TryParse(mtbDamageModifier.Text, out dmgMod))
            {
                MessageBox.Show("Damage Modifier must be an integer value");
                return;
            }
            List<string> allowedClasses = new List<string>();
            foreach (object o in lbAllowedClasses.Items)
                allowedClasses.Add(o.ToString());

            weapon = new WeaponData();
            weapon.Name = tbName.Text;
            weapon.Type = tbType.Text;
            weapon.Price = price;
            weapon.Weight = weight;
            weapon.NumberHands = (Hands)cboHands.SelectedIndex;
            weapon.AttackValue = atkVal;
            weapon.AttackModifier = atkMod;
            weapon.DamageValue = dmgVal;
            weapon.DamageModifier = dmgMod;
            weapon.AllowableClasses = allowedClasses.ToArray();

            this.FormClosing -= FormWeaponDetails_FormClosing;
            this.Close();
        }

        private void FormWeaponDetails_Load(object sender, EventArgs e)
        {
            foreach (string s in FormDetails.EntityDataManager.EntityData.Keys)
                lbClasses.Items.Add(s);
            foreach (Hands location in Enum.GetValues(typeof(Hands)))
                cboHands.Items.Add(location);
            cboHands.SelectedIndex = 0;
            if (weapon != null)
            {
                tbName.Text = weapon.Name;
                tbType.Text = weapon.Type;
                mtbPrice.Text = weapon.Price.ToString();
                nudWeight.Value = (decimal)weapon.Weight;
                cboHands.SelectedItem = (int)weapon.NumberHands;
                mtbAttackValue.Text = weapon.AttackValue.ToString();
                mtbAttackModifier.Text = weapon.AttackModifier.ToString();
                mtbDamageValue.Text = weapon.DamageValue.ToString();
                mtbDamageModifier.Text = weapon.DamageModifier.ToString();
                foreach(string s in weapon.AllowableClasses)
                {
                    if (lbClasses.Items.Contains(s))
                        lbClasses.Items.Remove(s);
                    lbAllowedClasses.Items.Add(s);
                }
            }
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
