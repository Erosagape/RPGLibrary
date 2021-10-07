using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ArmorData
    {
        public string Name;
        public string Type;
        public int Price;
        public float Weight;
        public bool Equipped;
        public ArmorLocation ArmorLocation;
        public int DefenseValue;
        public int DefenseModifier;
        public string[] AllowableClasses;
        public ArmorData()
        {

        }
        public override string ToString()
        {
            string str = Name + ", ";
            str += Type + ", ";
            str += Price.ToString() + ", ";
            str += Weight.ToString() + ", ";
            str += ArmorLocation.ToString() + ", ";
            str += DefenseModifier.ToString();
            foreach (string s in AllowableClasses)
                str += ", " + s;
            return str;
        }
    }
}
