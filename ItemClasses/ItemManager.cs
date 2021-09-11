using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ItemManager
    {
        Dictionary<string, Weapon> weapons = new Dictionary<string, Weapon>();
        Dictionary<string, Armor> armors = new Dictionary<string, Armor>();
        Dictionary<string, Shield> shields = new Dictionary<string, Shield>();
        public Dictionary<string,Weapon>.KeyCollection WeaponKeys
        {
            get { return weapons.Keys; }
        }
        public Dictionary<string, Armor>.KeyCollection ArmorKeys
        {
            get { return armors.Keys; }
        }
        public Dictionary<string, Shield>.KeyCollection ShieldKeys
        {
            get { return shields.Keys; }
        }
        public ItemManager()
        {

        }
        public void AddWeapon(Weapon wp)
        {
            if (!weapons.ContainsKey(wp.Name))
                weapons.Add(wp.Name, wp);
        }
        public void AddArmor(Armor arm)
        {
            if (!armors.ContainsKey(arm.Name))
                armors.Add(arm.Name, arm);
        }
        public void AddShield(Shield s)
        {
            if (!shields.ContainsKey(s.Name))
                shields.Add(s.Name, s);
        }
        public Weapon GetWeapon(string name)
        {
            if (weapons.ContainsKey(name))
                return (Weapon)weapons[name].Clone();
            return null;
        }
        public Armor GetArmor(string name)
        {
            if (armors.ContainsKey(name))
                return (Armor)armors[name].Clone();
            return null;
        }
        public Shield GetShield(string name)
        {
            if (shields.ContainsKey(name))
                return (Shield)shields[name].Clone();
            return null;
        }
        public bool ContainsWeapon(string name)
        {
            return weapons.ContainsKey(name);
        }
        public bool ContainsArmor(string name)
        {
            return armors.ContainsKey(name);
        }
        public bool ContainsShield(string name)
        {
            return shields.ContainsKey(name);
        }
    }
}
