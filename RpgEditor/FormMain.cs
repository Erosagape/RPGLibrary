using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using RpgLibrary;

namespace RpgEditor
{
    public partial class FormMain : Form
    {
        RolePlayingGame rpg;
        FormClasses frmClasses;
        FormArmor frmArmor;
        FormShield frmShield;
        FormWeapon frmWeapon;
        static string gamePath = "";
        static string classPath = "";
        static string itemPath = "";
        public static string GamePath
        {
            get { return gamePath; }
        }
        public static string ClassPath
        {
            get { return classPath; }
        }
        public static string ItemPath
        {
            get { return itemPath; }
        }

        public FormMain()
        {
            InitializeComponent();
            this.FormClosing += FormMain_FormClosing;
            newGameToolStripMenuItem.Click += NewGameToolStripMenuItem_Click;
            openGameToolStripMenuItem.Click += OpenGameToolStripMenuItem_Click;
            saveGameToolStripMenuItem.Click += SaveGameToolStripMenuItem_Click;
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            classesToolStripMenuItem.Click += ClassesToolStripMenuItem_Click;
            armorsToolStripMenuItem.Click += ArmorsToolStripMenuItem_Click;
            shieldsToolStripMenuItem.Click += ShieldsToolStripMenuItem_Click;
            weaponsToolStripMenuItem.Click += WeaponsToolStripMenuItem_Click;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlg = MessageBox.Show(
                "Unsave changes will be lost, are you sure you want to exit?",
                "Exit?",
                MessageBoxButtons.YesNo
                );
            if (dlg == DialogResult.No)
                e.Cancel = true;
        }

        private void WeaponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmWeapon == null)
            {
                frmWeapon = new FormWeapon();
                frmWeapon.MdiParent = this;
            }
            frmWeapon.Show();
            frmWeapon.BringToFront();
        }

        private void ShieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmShield == null)
            {
                frmShield = new FormShield();
                frmShield.MdiParent = this;
            }
            frmShield.Show();
            frmShield.BringToFront();
        }

        private void ArmorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmArmor == null)
            {
                frmArmor = new FormArmor();
                frmArmor.MdiParent = this;
            }
            frmArmor.Show();
            frmArmor.BringToFront();
        }

        private void ClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmClasses == null)
            {
                frmClasses = new FormClasses();
                frmClasses.MdiParent = this;
            }
            frmClasses.Show();
            frmClasses.BringToFront();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rpg != null)
            {
                try
                {
                    XnaSerializer.Serializer<RolePlayingGame>(gamePath + "/Game.xml", rpg);
                    FormDetails.WriteEntityData();
                    FormDetails.WriteItemData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void OpenGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Select Game Folder";
            dlg.SelectedPath = Application.StartupPath;
            bool tryAgain = false;
            do
            {
                DialogResult res = dlg.ShowDialog();
                DialogResult msgBoxResult;
                if (res == DialogResult.OK)
                {
                    if (File.Exists(dlg.SelectedPath + "/Game/Game.xml"))
                    {
                        try
                        {
                            OpenGame(dlg.SelectedPath);
                            tryAgain = false;
                        }
                        catch (Exception ex)
                        {
                            msgBoxResult = MessageBox.Show(
                                ex.ToString(),
                                "Try Again",
                                MessageBoxButtons.RetryCancel
                                );
                            if (msgBoxResult == DialogResult.Cancel)
                            {
                                tryAgain = false;
                            }
                            else if (msgBoxResult == DialogResult.Retry)
                            {
                                tryAgain = true;
                            }
                        }
                    }
                    else
                    {
                        msgBoxResult = MessageBox.Show(
                            "Game nof found,try again?",
                            "Confirm",
                            MessageBoxButtons.RetryCancel
                            );
                        if (msgBoxResult == DialogResult.Cancel)
                            tryAgain = false;
                        else if (msgBoxResult == DialogResult.Retry)
                            tryAgain = true;
                    }

                }
            } while (tryAgain);
        }
        private void OpenGame(string path)
        {
            gamePath=Path.Combine(path,"Game");
            classPath = Path.Combine(path, "Classes");
            itemPath = Path.Combine(path, "Items");
            rpg = XnaSerializer.Deserialize<RolePlayingGame>(gamePath + "/Game.xml");
            FormDetails.ReadEntityData();
            FormDetails.ReadItemData();
            PrepareForms();
        }
        private void PrepareForms()
        {
            if (frmClasses == null)
            {
                frmClasses = new FormClasses();
                frmClasses.MdiParent = this;
            }
            frmClasses.FillListBox();

            if (frmArmor == null)
            {
                frmArmor = new FormArmor();
                frmArmor.MdiParent = this;
            }            
            frmArmor.FillListBox();
            
            if (frmShield == null)
            {
                frmShield = new FormShield();
                frmShield.MdiParent = this;
            }
            frmShield.FillListBox();
            
            if (frmWeapon == null)
            {
                frmWeapon = new FormWeapon();
                frmWeapon.MdiParent = this;
            }
            frmWeapon.FillListBox();
            classesToolStripMenuItem.Enabled = true;
            armorsToolStripMenuItem.Enabled = true;
            weaponsToolStripMenuItem.Enabled = true;
            shieldsToolStripMenuItem.Enabled = true;
            itemsToolStripMenuItem.Enabled = true;
        }
        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(FormNewGame frm=new FormNewGame())
            {
                DialogResult result = frm.ShowDialog();
                if(result==DialogResult.OK && frm.RolePlayingGame != null)
                {
                    FolderBrowserDialog dlg = new FolderBrowserDialog();
                    dlg.Description="Select folder to create game in.";
                    dlg.SelectedPath = Application.StartupPath;
                    DialogResult dlgResult = dlg.ShowDialog();
                    if (dlgResult == DialogResult.OK)
                    {
                        try
                        {
                            gamePath = Path.Combine(dlg.SelectedPath, "Game");
                            classPath = Path.Combine(dlg.SelectedPath, "Classes");
                            itemPath = Path.Combine(dlg.SelectedPath, "Items");
                            if (Directory.Exists(gamePath))
                                throw new Exception("Directory already exists");

                            Directory.CreateDirectory(gamePath);
                            Directory.CreateDirectory(classPath);
                            Directory.CreateDirectory(itemPath + "/Armor");
                            Directory.CreateDirectory(itemPath + "/Shield");
                            Directory.CreateDirectory(itemPath + "/Weapon");

                            rpg = frm.RolePlayingGame;

                            XnaSerializer.Serializer<RolePlayingGame>(gamePath + "/Game.xml",rpg);                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            return;
                        }
                    }
                    classesToolStripMenuItem.Enabled = true;
                    armorsToolStripMenuItem.Enabled = true;
                    weaponsToolStripMenuItem.Enabled = true;
                    shieldsToolStripMenuItem.Enabled = true;
                    itemsToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
    }
}
