using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RpgLibrary;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;
using RpgLibrary.SkillClasses;
namespace RpgEditor
{
    public partial class FormDetails : Form
    {
        public static ItemDataManager ItemManager;
        public static EntityDataManager EntityDataManager;
        protected static SkillDataManager skillManager;
        public static SkillDataManager SkillManager
        {
            get { return skillManager; }
        }
        public FormDetails()
        {
            InitializeComponent();
            if (ItemManager == null)
                ItemManager = new ItemDataManager();
            if (EntityDataManager == null)
                EntityDataManager = new EntityDataManager();

            this.FormClosing += FormDetails_FormClosing;
        }
        public static void ReadEntityData()
        {
            EntityDataManager = new EntityDataManager();
            string[] fileNames = Directory.GetFiles(FormMain.ClassPath, "*.xml");
            foreach (string s in fileNames)
            {
                EntityData data = XnaSerializer.Deserialize<EntityData>(s);
                EntityDataManager.EntityData.Add(data.EntityName, data);
            }
        }
        public static void ReadItemData()
        {
            ItemManager = new ItemDataManager();
            string[] fileNames = Directory.GetFiles(Path.Combine(FormMain.ItemPath, "Armor"), "*.xml");
            foreach (string s in fileNames)
            {
                ArmorData data = XnaSerializer.Deserialize<ArmorData>(s);
                ItemManager.ArmorData.Add(data.Name, data);
            }
            fileNames = Directory.GetFiles(Path.Combine(FormMain.ItemPath, "Shield"), "*.xml");
            foreach (string s in fileNames)
            {
                ShieldData data = XnaSerializer.Deserialize<ShieldData>(s);
                ItemManager.ShieldData.Add(data.Name, data);
            }
            fileNames = Directory.GetFiles(Path.Combine(FormMain.ItemPath, "Weapon"), "*.xml");
            foreach (string s in fileNames)
            {
                WeaponData data = XnaSerializer.Deserialize<WeaponData>(s);
                ItemManager.WeaponData.Add(data.Name, data);
            }
        }
        public static void WriteEntityData()
        {
            foreach (string s in EntityDataManager.EntityData.Keys)
            {
                XnaSerializer.Serializer<EntityData>(
                    FormMain.ClassPath + "/" + s + ".xml",
                    EntityDataManager.EntityData[s]
                    );
            }
        }
        public static void WriteItemData()
        {
            foreach (string s in ItemManager.ArmorData.Keys)
            {
                XnaSerializer.Serializer<ArmorData>(
                    FormMain.ItemPath + "/Armor/" + s + ".xml",
                    ItemManager.ArmorData[s]
                    );
            }
            foreach (string s in ItemManager.ShieldData.Keys)
            {
                XnaSerializer.Serializer<ShieldData>(
                    FormMain.ItemPath + "/Shield/" + s + ".xml",
                    ItemManager.ShieldData[s]
                    );
            }
            foreach (string s in ItemManager.WeaponData.Keys)
            {
                XnaSerializer.Serializer<WeaponData>(
                    FormMain.ItemPath + "/Weapon/" + s + ".xml",
                    ItemManager.WeaponData[s]
                    );
            }
        }
        public static void WriteKeyData()
        {
            foreach (string s in ItemManager.KeyData.Keys)
            {
                XnaSerializer.Serializer<KeyData>(
                    FormMain.KeyPath + "/" + s + ".xml",
                    ItemManager.KeyData[s]
                    );
            }
        }
        public static void WriteChestData()
        {
            foreach (string s in ItemManager.ChestData.Keys)
            {
                XnaSerializer.Serializer<ChestData>(
                    FormMain.ChestPath + "/" + s + ".xml",
                    ItemManager.ChestData[s]
                    );
            }
        }
        public static void ReadKeyData()
        {
            string[] filenames = Directory.GetFiles(FormMain.KeyPath, "*.xml");
            foreach (string s in filenames)
            {
                KeyData keyData = XnaSerializer.Deserialize<KeyData>(s);
                ItemManager.KeyData.Add(keyData.Name, keyData);
            }
        }
        public static void ReadChestData()
        {
            string[] filenames = Directory.GetFiles(FormMain.ChestPath, "*.xml");
            foreach(string s in filenames)
            {
                ChestData chestData = XnaSerializer.Deserialize<ChestData>(s);
                ItemManager.ChestData.Add(chestData.Name, chestData);
            }
        }
    
        private void FormDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            if (e.CloseReason == CloseReason.MdiFormClosing)
            {
                e.Cancel = false;
                this.Close();
            }
        }
        public static void WriteSkillData()
        {
            foreach(string s in SkillManager.SkillData.Keys)
            {
                XnaSerializer.Serializer<SkillData>(
                    FormMain.SkillPath + "/" + s + ".xml",
                    SkillManager.SkillData[s]
                    );
            }
        }
        public static void ReadSkillData()
        {
            skillManager = new SkillDataManager();
            string[] fileNames = Directory.GetFiles(FormMain.SkillPath, "*.xml");
            foreach(string s in fileNames)
            {
                SkillData skill = XnaSerializer.Deserialize<SkillData>(s);
                skillManager.SkillData.Add(skill.Name, skill);
            }
        }
    }
}
