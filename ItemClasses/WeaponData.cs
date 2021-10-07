using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class WeaponData
    {
        public string Name;
        public string Type;
        public int Price;
        public float Weight;
        public bool Equipped;
        public Hands NumberHands;
        public int AttackValue;
        public int AttackModifier;
        public int DamageValue;
        public int DamageModifier;
        public string[] AllowableClasses;
        public WeaponData()
        {

        }
        public override string ToString()
        {
            string str = Name + ", ";
            str += Type + ", ";
            str += Price.ToString() + ", ";
            str += Weight.ToString() + ", ";
            str += NumberHands.ToString() + ", ";
            str += AttackValue.ToString() + ", "; 
            str += AttackModifier.ToString() + ", ";
            str += DamageValue.ToString() + ", ";
            str += DamageModifier.ToString();
            foreach (string s in AllowableClasses)
                str += ", " + s;
            return str;
        }
    }
}
