using RpgLibrary.ItemClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            if (lbDetails.SelectedItem != null)
            {
                string detail = (string)lbDetails.SelectedItem;
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();
                DialogResult dlg = MessageBox.Show(
                    "Are you sure you want to delete " + entity + "?",
                    "Delete",
                    MessageBoxButtons.YesNo
                    );
                if (dlg == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    ItemManager.WeaponData.Remove(entity);
                    if (File.Exists(FormMain.ItemPath + "/Weapon/" + entity + ".xml"))
                        File.Delete(FormMain.ItemPath + "/Weapon/" + entity + ".xml");
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();
                WeaponData data = ItemManager.WeaponData[entity];
                WeaponData newData = null;
                using (FormWeaponDetails frm = new FormWeaponDetails())
                {
                    frm.Weapon = data;
                    frm.ShowDialog();
                    if (frm.Weapon == null)
                        return;
                    if (frm.Weapon.Name == entity)
                    {
                        ItemManager.WeaponData[entity] = frm.Weapon;
                        FillListBox();
                        return;
                    }
                    newData = frm.Weapon;
                }
                DialogResult dlg = MessageBox.Show(
                    "Name has changed, Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo
                    );
                if (dlg == DialogResult.No)
                    return;
                if (ItemManager.WeaponData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use edit to modify");
                    return;
                }
                lbDetails.Items.Add(newData);
                ItemManager.WeaponData.Add(newData.Name, newData);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (FormWeaponDetails frm = new FormWeaponDetails())
            {
                frm.ShowDialog();
                if (frm.Weapon != null)
                {
                    AddWeapon(frm.Weapon);
                }
            }
        }

        private void AddWeapon(WeaponData weapon)
        {
            if (FormDetails.ItemManager.WeaponData.ContainsKey(weapon.Name))
            {
                DialogResult dlg = MessageBox.Show(
                    weapon.Name + " already exists, Overwrite?",
                    "Replace",
                    MessageBoxButtons.YesNo
                    );
                if (dlg == DialogResult.No)
                    return;
                ItemManager.WeaponData[weapon.Name] = weapon;
                FillListBox();
                return;
            }
            ItemManager.WeaponData.Add(weapon.Name, weapon);
            lbDetails.Items.Add(weapon);
        }
    }
}
