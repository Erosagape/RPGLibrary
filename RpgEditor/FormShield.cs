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
                    ItemManager.ShieldData.Remove(entity);
                    if (File.Exists(FormMain.ItemPath + "/Shield/" + entity + ".xml"))
                        File.Delete(FormMain.ItemPath + "/Shield/" + entity + ".xml");
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
                ShieldData data = ItemManager.ShieldData[entity];
                ShieldData newData = null;
                using (FormShieldDetails frm = new FormShieldDetails())
                {
                    frm.Shield = data;
                    frm.ShowDialog();
                    if (frm.Shield == null)
                        return;
                    if (frm.Shield.Name == entity)
                    {
                        ItemManager.ShieldData[entity] = frm.Shield;
                        FillListBox();
                        return;
                    }
                    newData = frm.Shield;
                }
                DialogResult dlg = MessageBox.Show(
                    "Name has changed, Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo
                    );
                if (dlg == DialogResult.No)
                    return;
                if (ItemManager.ShieldData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use edit to modify");
                    return;
                }
                lbDetails.Items.Add(newData);
                ItemManager.ShieldData.Add(newData.Name, newData);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (FormShieldDetails frm = new FormShieldDetails())
            {
                frm.ShowDialog();
                if (frm.Shield != null)
                {
                    AddShield(frm.Shield);
                }
            }
        }

        private void AddShield(ShieldData shield)
        {
            if (FormDetails.ItemManager.ShieldData.ContainsKey(shield.Name))
            {
                DialogResult dlg = MessageBox.Show(
                    shield.Name + " already exists, Overwrite?",
                    "Replace",
                    MessageBoxButtons.YesNo
                    );
                if (dlg == DialogResult.No)
                    return;
                ItemManager.ShieldData[shield.Name] = shield;
                FillListBox();
                return;
            }
            ItemManager.ShieldData.Add(shield.Name, shield);
            lbDetails.Items.Add(shield);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
