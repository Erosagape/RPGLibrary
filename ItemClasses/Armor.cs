using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Armor :BaseItem
    {
        ArmorLocation location;
        int defenseValue;
        int defenseModifier;
        public ArmorLocation Location
        {
            get { return location; }
            protected set { location = value; }
        }
        public int DefenseValue
        {
            get { return defenseValue; }
            protected set { defenseValue = value; }
        }
        public int DefenseModifier
        {
            get { return defenseModifier; }
            protected set { defenseModifier = value; }
        }
        public Armor
            (
            string name,
            string type,
            int price,
            float weight,
            ArmorLocation locate,
            int def,
            int defMod,
            params string[] allowClasses
            ) :base(name,type,price,weight,allowClasses)
        {
            Location = locate;
            DefenseValue = def;
            DefenseModifier = defMod;
        }
        public override object Clone()
        {
            string[] allowClass = new string[allowableClasses.Count];
            for(int i=0;i< allowableClasses.Count; i++)
            {
                allowClass[i] = allowableClasses[i];
            }
            Armor arms = new Armor(
                Name,Type,Price,Weight,Location,DefenseValue,DefenseModifier,allowClass
                );
            return arms;
        }
        public override string ToString()
        {
            string armorString = base.ToString() + ", ";
            armorString += Location.ToString() + ", ";
            armorString += DefenseValue.ToString() + ", ";
            armorString += DefenseModifier.ToString();
            foreach (string t in allowableClasses)
                armorString += ", " + t;
            return armorString;
        }
    }
}
