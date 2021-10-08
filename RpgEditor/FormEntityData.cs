using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.CharacterClasses;
namespace RpgEditor
{
    public partial class FormEntityData : Form
    {
        EntityData entityData = null;
        public EntityData EntityData
        {
            get { return entityData; }
            set { entityData = value; }
        }
        public FormEntityData()
        {
            InitializeComponent();
            this.Load += FormEntityData_Load;
            this.FormClosing += FormEntityData_FormClosing;
            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            entityData = null;
            this.FormClosing -= FormEntityData_FormClosing;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbName.Text)||
               string.IsNullOrEmpty(tbHealth.Text) ||
               string.IsNullOrEmpty(tbStamina.Text) ||
               string.IsNullOrEmpty(tbMana.Text))
            {
                MessageBox.Show("Name And Formulas must have values", "Error");
                return;
            }
            int str = 0, dex = 0, cun = 0, wil = 0, mag = 0, con = 0;
            if(!int.TryParse(mtbStrength.Text,out str))
            {
                MessageBox.Show("Strength must be numeric");
                return;
            }
            if (!int.TryParse(mtbDexterity.Text, out dex))
            {
                MessageBox.Show("Dexterity must be numeric");
                return;
            }
            if (!int.TryParse(mtbCunning.Text, out cun))
            {
                MessageBox.Show("Cunning must be numeric");
                return;
            }
            if (!int.TryParse(mtbWillPower.Text, out wil))
            {
                MessageBox.Show("Will Power must be numeric");
                return;
            }
            if (!int.TryParse(mtbMagic.Text, out mag))
            {
                MessageBox.Show("Magic must be numeric");
                return;
            }
            if (!int.TryParse(mtbConstitution.Text, out con))
            {
                MessageBox.Show("Constitution must be numeric");
                return;
            }
            entityData = new EntityData(
                tbName.Text,str,dex,cun,wil,mag,con,tbHealth.Text,tbStamina.Text,tbMana.Text
                );
            this.FormClosing -= FormEntityData_FormClosing;
            this.Close();
        }

        private void FormEntityData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void FormEntityData_Load(object sender, EventArgs e)
        {
            if (entityData != null)
            {
                tbName.Text = entityData.EntityName;
                mtbStrength.Text = entityData.Strength.ToString();
                mtbDexterity.Text = entityData.Dexterity.ToString();
                mtbCunning.Text = entityData.Cunning.ToString();
                mtbWillPower.Text = entityData.WillPower.ToString();
                mtbMagic.Text = entityData.Magic.ToString();
                mtbConstitution.Text = entityData.Constitution.ToString();
                tbHealth.Text = entityData.HealthFormula;
                tbStamina.Text = entityData.StaminaFormula;
                tbMana.Text = entityData.MagicFormula;
            }
        }
    }
}
