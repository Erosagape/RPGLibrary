using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RpgLibrary;
namespace RpgEditor
{
    public partial class FormNewGame : Form
    {
        RolePlayingGame rpg;
        public RolePlayingGame RolePlayingGame
        {
            get { return rpg; }
        }
        public FormNewGame()
        {
            InitializeComponent();
            btnOK.Click += btnOK_Click;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text)||
                string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("You must enter a name and a description", "Error");
                return;
            }
            rpg = new RolePlayingGame(txtName.Text, txtDescription.Text);
            this.Close();
        }

        private void FormNewGame_Load(object sender, EventArgs e)
        {

        }
    }
}
