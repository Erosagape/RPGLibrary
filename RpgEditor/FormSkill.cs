using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using RpgLibrary.SkillClasses;
namespace RpgEditor
{
    public partial class FormSkill : FormDetails
    {
        public FormSkill()
        {
            InitializeComponent();
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using(FormSkillDetails frm=new FormSkillDetails())
            {
                frm.ShowDialog();
                if (frm.Skill != null)
                {
                    AddSkill(frm.Skill);
                }
            }
        }

        private void AddSkill(SkillData skill)
        {
            if (FormDetails.SkillManager.SkillData.ContainsKey(skill.Name))
            {
                DialogResult result = MessageBox.Show(
                    skill.Name + " already exists. Overwrite it?",
                    "Existing data",
                    MessageBoxButtons.YesNo
                    );
                if (result == DialogResult.No)
                    return;
                skillManager.SkillData[skill.Name] = skill;
                FillListBox();
                return;
            }
            SkillManager.SkillData.Add(skill.Name, skill);
            lbDetails.Items.Add(skill);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();
                SkillData data = skillManager.SkillData[entity];
                SkillData newData = null;
                using(FormSkillDetails frm=new FormSkillDetails())
                {
                    frm.Skill = data;
                    frm.ShowDialog();
                    if (frm.Skill == null)
                        return;
                    if (frm.Skill.Name == entity)
                    {
                        skillManager.SkillData[entity] = frm.Skill;
                        FillListBox();
                        return;
                    }
                    newData = frm.Skill;
                }
                DialogResult result = MessageBox.Show(
                    "Name has changed. Do you want to add new entry?", "New Entry", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
                if (skillManager.SkillData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use edit to modify the entry.");
                    return;
                }
                lbDetails.Items.Add(newData);
                skillManager.SkillData.Add(newData.Name, newData);
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
                    "Are you sure you want to delete " + entity + "?","Delete",MessageBoxButtons.YesNo
                    );
                if (result == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    skillManager.SkillData.Remove(entity);
                    if(File.Exists(FormMain.SkillPath+"/"+ entity + ".xml"))
                    {
                        File.Delete(FormMain.SkillPath + "/" + entity + ".xml");
                    }
                }
            }
        }
        public void FillListBox()
        {
            lbDetails.Items.Clear();
            foreach (string s in FormDetails.SkillManager.SkillData.Keys)
                lbDetails.Items.Add(FormDetails.SkillManager.SkillData[s]);
        }
    }
}
