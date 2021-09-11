using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ItemDataManager
    {
        Dictionary<string, ArmorData> armorData = new Dictionary<string, ArmorData>();
        Dictionary<string, ShieldData> shieldData = new Dictionary<string, ShieldData>();
        Dictionary<string, WeaponData> weaponData = new Dictionary<string, WeaponData>();
        public Dictionary<string,ArmorData> ArmorData
        {
            get { return armorData; }
            set { armorData = value; }
        }
        public Dictionary<string, ShieldData> ShieldData
        {
            get { return shieldData; }
            set { shieldData = value; }
        }
        public Dictionary<string, WeaponData> WeaponData
        {
            get { return weaponData; }
            set { weaponData = value; }
        }

    }
}
