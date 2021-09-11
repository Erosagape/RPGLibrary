using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Shield :BaseItem
    {
        int defenseValue;
        int defenseModifier;
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
        public Shield(
            string name,
            string type,
            int price,
            float weight,
            int def,
            int defMod,
            params string[] allowClasses
            ) :base(name,type,price,weight,allowClasses)
        {
            DefenseValue = defenseValue;
            DefenseModifier = defenseModifier;
        }
        public override object Clone()
        {
            string[] allowClasses = new string[allowableClasses.Count];
            for (int i = 0; i < allowableClasses.Count; i++)
                allowClasses[i] = allowableClasses[i];
            Shield s = new Shield(
                Name,Type,Price,Weight,DefenseValue,DefenseModifier,allowClasses
                );
            return s;
        }
        public override string ToString()
        {
            string shieldString = base.ToString() + ", ";
            shieldString += DefenseValue.ToString() + ", ";
            shieldString += DefenseModifier.ToString();
            foreach (string t in allowableClasses)
                shieldString += ", " + t;
            return shieldString;
        }
    }
}
