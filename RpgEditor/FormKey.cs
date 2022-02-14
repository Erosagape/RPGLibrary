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
    public partial class FormKey : FormDetails
    {
        public FormKey()
        {
            InitializeComponent();
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using(FormKeyDetails frmKeyDetails =new FormKeyDetails())
            {
                frmKeyDetails.ShowDialog();
                if (frmKeyDetails.Key != null)
                {
                    AddKey(frmKeyDetails.Key);
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

                KeyData data = ItemManager.KeyData[entity];
                KeyData newData = null;

                using(FormKeyDetails frmKeyDetails=new FormKeyDetails())
                {
                    frmKeyDetails.Key = data;
                    frmKeyDetails.ShowDialog();
                    if (frmKeyDetails.Key == null)
                        return;
                    if (frmKeyDetails.Key.Name == entity)
                    {
                        ItemManager.KeyData[entity] = frmKeyDetails.Key;
                        FillListBox();
                        return;
                    }
                    newData = frmKeyDetails.Key;
                }
                DialogResult dlg = MessageBox.Show(
                    "Name has changed,Do you want to add a new entry?","Confirm",MessageBoxButtons.YesNo
                    );
                if (dlg == DialogResult.No)
                    return;
                if (ItemManager.KeyData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entity already exist, use Edit to modify the entry");
                    return;
                }
                lbDetails.Items.Add(newData);
                ItemManager.KeyData.Add(newData.Name, newData);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = (string)lbDetails.SelectedItem;
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete " + entity + "?","Confirm",MessageBoxButtons.YesNo
                    );
                if (result == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    ItemManager.KeyData.Remove(entity);
if(File.Exists(FormMain.ItemPath + "/Key/"+ entity + ".xml"))
                    {
                        File.Delete(FormMain.ItemPath + "/Key/" + entity + ".xml");
                    }                 
                }
            }
        }
        public void FillListBox()
        {
            lbDetails.Items.Clear();
            foreach (string s in FormDetails.ItemManager.KeyData.Keys)
                lbDetails.Items.Add(FormDetails.ItemManager.KeyData[s]);
        }
        private void AddKey(KeyData keyData)
        {
            if (FormDetails.ItemManager.KeyData.ContainsKey(keyData.Name))
            {
                DialogResult dlg = MessageBox.Show(
                    keyData.Name + " already exists. overwrite it?","Confirm",MessageBoxButtons.YesNo
                    );
                if (dlg == DialogResult.No)
                    return;
                ItemManager.KeyData[keyData.Name] = keyData;
                FillListBox();
                return;
            }
            ItemManager.KeyData.Add(keyData.Name, keyData);
            lbDetails.Items.Add(keyData);
        }
    }
}
