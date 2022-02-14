using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.SkillClasses;
namespace RpgEditor
{
    public partial class FormSkillDetails : Form
    {
        SkillData skill;
        public SkillData Skill
        {
            get { return skill; }
            set { skill = value; }
        }
        public FormSkillDetails()
        {
            InitializeComponent();
            this.Load += FormSkillDetails_Load;
            this.FormClosing += FormSkillDetails_FormClosing;
            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void FormSkillDetails_Load(object sender, EventArgs e)
        {
            if (Skill != null)
            {
                tbName.Text = skill.Name;
                switch (Skill.PrimaryAttribute.ToLower())
                {
                    case "strength":
                        rbStrength.Checked = true;
                        break;
                    case "dexterity":
                        rbDexterity.Checked = true;
                        break;
                    case "cunning":
                        rbCunning.Checked = true;
                        break;
                    case "willpower":
                        rbWillpower.Checked = true;
                        break;
                    case "magic":
                        rbMagic.Checked = true;
                        break;
                    case "constitution":
                        rbConstitution.Checked = true;
                        break;
                }
                foreach(string s in Skill.ClassModifiers.Keys)
                {
                    string data = s + ", " + skill.ClassModifiers[s].ToString();
                    lbModifiers.Items.Add(data);
                }
            }
        }

        private void FormSkillDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("you must provide a name for the skill");
                return;
            }
            SkillData newSkill = new SkillData();
            newSkill.Name = tbName.Text;
            if (rbStrength.Checked)
                newSkill.PrimaryAttribute = "Strength";
            if (rbDexterity.Checked)
                newSkill.PrimaryAttribute = "Dexterity";
            if (rbCunning.Checked)
                newSkill.PrimaryAttribute = "Cunning";
            if (rbWillpower.Checked)
                newSkill.PrimaryAttribute = "WillPower";
            if (rbMagic.Checked)
                newSkill.PrimaryAttribute = "Magic";
            if (rbConstitution.Checked)
                newSkill.PrimaryAttribute = "Constitution";
            skill = newSkill;
            this.FormClosing -= FormSkillDetails_FormClosing;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            skill = null;
            this.FormClosing -= FormSkillDetails_FormClosing;
            this.Close();
        }
    }
}
