using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;
namespace RpgEditor
{
    public partial class FormClasses : FormDetails
    {
        public FormClasses()
        {
            InitializeComponent();
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
        }
        private void AddEntity(EntityData data)
        {
            if (FormDetails.EntityDataManager.EntityData.ContainsKey(data.EntityName))
            {
                DialogResult res = MessageBox.Show(
                    data.EntityName + " exist,overwrite?",
                    "Warning",
                    MessageBoxButtons.YesNo
                    );
                if (res == DialogResult.No)
                    return;

                FormDetails.EntityDataManager.EntityData[data.EntityName] = data;
                FillListBox();
                return;
            }
            lbDetails.Items.Add(data.ToString());
            FormDetails.EntityDataManager.EntityData.Add(data.EntityName, data);
        }
        public void FillListBox()
        {
            lbDetails.Items.Clear();
            foreach (string s in FormDetails.EntityDataManager.EntityData.Keys)
                lbDetails.Items.Add(FormDetails.EntityDataManager.EntityData[s]);
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(lbDetails.SelectedItem != null)
            {
                string detail = (string)lbDetails.SelectedItem;
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();
                DialogResult result = MessageBox.Show(
"Are you sure you want to delete " + entity +"?",
"Delete",
MessageBoxButtons.YesNo
                    );
                if (result == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    EntityDataManager.EntityData.Remove(entity);
                    if (File.Exists(FormMain.ClassPath + "/" + entity + ".xml"))
                        File.Delete(FormMain.ClassPath + "/" + entity + ".xml");
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = (string)lbDetails.SelectedItem;
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();
                EntityData data = EntityDataManager.EntityData[entity];
                EntityData newData = null;
                using(FormEntityData frm=new FormEntityData())
                {
                    frm.EntityData = data;
                    frm.ShowDialog();
                    if (frm.EntityData == null)
                        return;
                    if (frm.EntityData.EntityName == entity)
                    {
                        EntityDataManager.EntityData[entity] = frm.EntityData;
                        FillListBox();
                        return;
                    }
                    newData = frm.EntityData;
                }
                DialogResult result = MessageBox.Show(
                    "Name has changed. Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo
                    );
                if (result == DialogResult.No)
                    return;
                if (EntityDataManager.EntityData.ContainsKey(newData.EntityName))
                {
                    MessageBox.Show("Entry already exists. Use edit to modify the entry");
                    return;
                }
                lbDetails.Items.Add(newData);
                EntityDataManager.EntityData.Add(newData.EntityName, newData);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (FormEntityData frm = new FormEntityData())
            {
                frm.ShowDialog();
                if(frm.EntityData != null)
                {
                    lbDetails.Items.Add(frm.EntityData.ToString());
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
