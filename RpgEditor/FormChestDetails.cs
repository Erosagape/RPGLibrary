using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.ItemClasses;
using RpgLibrary.TrapClasses;
using RpgLibrary.SkillClasses;
namespace RpgEditor
{
    public partial class FormChestDetails : Form
    {
        ChestData chest;
        public ChestData Chest
        {
            get { return chest; }
            set { chest = value; }
        }
        public FormChestDetails()
        {
            InitializeComponent();
            this.Load += FormChestDetails_Load;
            this.FormClosing += FormChestDetails_FormClosing;
            foreach (string s in Enum.GetNames(typeof(DifficultyLevel)))
            {
                cboDifficulty.Items.Add(s);                
            }
            cboDifficulty.SelectedIndex = 0;
            cbLock.CheckedChanged += CbLock_CheckedChanged;
            cbTrap.CheckedChanged += CbTrap_CheckedChanged;
            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            chest = null;
            this.FormClosing -= FormChestDetails_FormClosing;
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a name for the chest.");
                return;
            }
            if(cbTrap.Checked && string.IsNullOrEmpty(tbTrap.Text))
            {
                MessageBox.Show("You must supply a name for the trap on the chest.");
                return;
            }
            if(nudMaxGold.Value< nudMinGold.Value)
            {
                MessageBox.Show("Maximum gold in chest must be greater or equal to minimum gold.");
                return;
            }
            ChestData data = new ChestData();
            data.Name = tbName.Text;
            data.IsLocked = cbLock.Checked;
            if (cbLock.Checked)
            {
                data.DifficultyLevel = (DifficultyLevel)Enum.Parse(typeof(DifficultyLevel), cboDifficulty.Text, true);
                data.KeyName = tbKeyName.Text;
                data.KeyType = tbKeyType.Text;
                data.KeysRequired = (int)nudKeys.Value;
            }
            data.IsTrapped = cbTrap.Checked;
            if (cbTrap.Checked)
            {
                data.TrapName = tbTrap.Text;
            }
            data.MinGold = (int)nudMinGold.Value;
            data.MaxGold = (int)nudMaxGold.Value;
            chest = data;
            this.FormClosing -= FormChestDetails_FormClosing;
            this.Close();
        }

        private void CbTrap_CheckedChanged(object sender, EventArgs e)
        {
            tbTrap.Enabled = cbTrap.Checked;
        }

        private void CbLock_CheckedChanged(object sender, EventArgs e)
        {
            cboDifficulty.Enabled = cbLock.Checked;
            tbKeyName.Enabled = cbLock.Checked;
            tbKeyType.Enabled = cbLock.Checked;
            nudKeys.Enabled = cbLock.Checked;
        }

        private void FormChestDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void FormChestDetails_Load(object sender, EventArgs e)
        {
            if (chest != null)
            {
                tbName.Text = chest.Name;
                cboDifficulty.SelectedText = Enum.GetName(typeof(DifficultyLevel),chest.DifficultyLevel);
                cbLock.Checked = chest.IsLocked;
                tbKeyName.Text = chest.KeyName;
                tbKeyType.Text = chest.KeyType;
                nudKeys.Value = (decimal)chest.KeysRequired;
                tbKeyName.Enabled = chest.IsLocked;
                tbKeyType.Enabled = chest.IsLocked;
                nudKeys.Enabled = chest.IsLocked;
                cbTrap.Checked = chest.IsTrapped;
                tbTrap.Text = chest.TrapName;
                tbTrap.Enabled = chest.IsTrapped;
                nudMinGold.Value = (decimal)chest.MinGold;
                nudMaxGold.Value = (decimal)chest.MaxGold;
            }
        }
    }
}
