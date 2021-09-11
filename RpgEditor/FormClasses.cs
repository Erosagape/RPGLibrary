using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            throw new NotImplementedException();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
