using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.ItemClasses;
namespace RpgEditor
{
    public partial class FormChest : FormDetails
    {
        public FormChest()
        {
            InitializeComponent();
            btnDelete.Click += BtnDelete_Click;
            btnEdit.Click += BtnEdit_Click;
            btnAdd.Click += BtnAdd_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using(FormChestDetails frm=new FormChestDetails())
            {
                frm.ShowDialog();
                if (frm.Chest != null)
                {
                    AddChest(frm.Chest);
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
                ChestData data = ItemManager.ChestData[entity];
                ChestData newData = null;
                using(FormChestDetails frm=new FormChestDetails())
                {
                    frm.Chest = data;
                    frm.ShowDialog();
                    if (frm.Chest == null)
                        return;
                    if (frm.Chest.Name == entity)
                    {
                        ItemManager.ChestData[entity] = frm.Chest;
                        FillListBox();
                        return;
                    }
                    newData = frm.Chest;
                }
                DialogResult result = MessageBox.Show(
                    "Name has changed, Do you want to add a new entry?","Confirm",MessageBoxButtons.YesNo
                    );
                if (result == DialogResult.No)
                    return;
                if (ItemManager.ChestData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exist, Use edit to modify the data.");
                    return;
                }
                lbDetails.Items.Add(newData);
                ItemManager.ChestData.Add(newData.Name, newData);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();
                DialogResult result = MessageBox.Show("Are you sure you want to delete " + entity + "?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    ItemManager.ChestData.Remove(entity);
                    if (File.Exists(FormMain.ItemPath + "/Chests/" + entity + ".xml"))
                        File.Delete(FormMain.ItemPath + "/Chests/" + entity + ".xml");                 
                }
            }
        }
        private void AddChest(ChestData chest)
        {
            if (FormDetails.ItemManager.ChestData.ContainsKey(chest.Name))
            {
                DialogResult result = MessageBox.Show(
                    chest.Name +" already exist, overwrite it?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
                ItemManager.ChestData[chest.Name] = chest;
                FillListBox();
                return;
            }
            ItemManager.ChestData.Add(chest.Name, chest);
            lbDetails.Items.Add(chest);
        }
        public void FillListBox()
        {
            lbDetails.Items.Clear();
            foreach (string s in FormDetails.ItemManager.ChestData.Keys)
                lbDetails.Items.Add(FormDetails.ItemManager.ChestData[s]);
        }
    }
}
