﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ItemDataManager
    {
        readonly Dictionary<string, ArmorData> armorData = new Dictionary<string, ArmorData>();
        readonly Dictionary<string, ShieldData> shieldData = new Dictionary<string, ShieldData>();
        readonly Dictionary<string, WeaponData> weaponData = new Dictionary<string, WeaponData>();
        readonly Dictionary<string, ReagentData> reagentData = new Dictionary<string, ReagentData>();
        public Dictionary<string,ArmorData> ArmorData
        {
            get { return armorData; }
        }
        public Dictionary<string, ShieldData> ShieldData
        {
            get { return shieldData; }
        }
        public Dictionary<string, WeaponData> WeaponData
        {
            get { return weaponData; }
        }
        public Dictionary<string,ReagentData> ReagentData
        {
            get { return reagentData; }
        }
    }
}
