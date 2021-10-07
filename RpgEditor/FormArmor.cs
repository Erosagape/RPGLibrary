using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;
namespace RpgEditor
{
    public partial class FormArmor : FormDetails
    {
        public FormArmor()
        {
            InitializeComponent();
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
        }
        public void FillListBox()
        {
            lbDetails.Items.Clear();
            foreach (string s in FormDetails.ItemManager.ArmorData.Keys)
                lbDetails.Items.Add(FormDetails.ItemManager.ArmorData[s]);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = (string)lbDetails.SelectedItem;
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();
                DialogResult dlg = MessageBox.Show(
                    "Are you sure you want to delete " + entity +"?",
                    "Delete",
                    MessageBoxButtons.YesNo
                    );
                if (dlg == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    ItemManager.ArmorData.Remove(entity);
                    if (File.Exists(FormMain.ItemPath + "/Armor/" + entity + ".xml"))
                        File.Delete(FormMain.ItemPath + "/Armor/" + entity + ".xml");
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
                ArmorData data = ItemManager.ArmorData[entity];
                ArmorData newData = null;
                using(FormArmorDetails frm=new FormArmorDetails())
                {
                    frm.Armor = data;
                    frm.ShowDialog();
                    if (frm.Armor == null)
                        return;
                    if (frm.Armor.Name == entity)
                    {
                        ItemManager.ArmorData[entity] = frm.Armor;
                        FillListBox();
                        return;
                    }
                    newData = frm.Armor;
                }
                DialogResult dlg = MessageBox.Show(
                    "Name has changed, Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo
                    );
                if (dlg == DialogResult.No)
                    return;
                if (ItemManager.ArmorData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use edit to modify");
                    return;
                }
                lbDetails.Items.Add(newData);
                ItemManager.ArmorData.Add(newData.Name, newData);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using(FormArmorDetails frm=new FormArmorDetails())
            {
                frm.ShowDialog();
                if (frm.Armor != null)
                {
                    AddArmor(frm.Armor);
                }
            }
        }

        private void AddArmor(ArmorData armor)
        {
            if (FormDetails.ItemManager.ArmorData.ContainsKey(armor.Name))
            {
                DialogResult dlg = MessageBox.Show(
                    armor.Name + " already exists, Overwrite?",
                    "Replace",
                    MessageBoxButtons.YesNo
                    );
                if (dlg == DialogResult.No)
                    return;
                ItemManager.ArmorData[armor.Name] = armor;
                FillListBox();
                return;
            }
            ItemManager.ArmorData.Add(armor.Name, armor);
            lbDetails.Items.Add(armor);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
