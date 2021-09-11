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
namespace RpgEditor
{
    public partial class FormDetails : Form
    {
        protected static ItemDataManager ItemManager;
        protected static EntityDataManager EntityDataManager;
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
            foreach(string s in fileNames)
            {
                EntityData data = XnaSerializer.Deserialize<EntityData>(s);
                EntityDataManager.EntityData.Add(data.EntityName, data);
            }
        }
        public static void ReadItemData()
        {
            ItemManager = new ItemDataManager();
            string[] fileNames = Directory.GetFiles(Path.Combine(FormMain.ItemPath, "Armor"), "*.xml");
            foreach(string s in fileNames)
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
            foreach(string s in EntityDataManager.EntityData.Keys)
            {
                XnaSerializer.Serializer<EntityData>(
                    FormMain.ClassPath + "/"+ s + ".xml",
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
    }
}
