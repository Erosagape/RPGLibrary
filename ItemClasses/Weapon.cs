using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Weapon :BaseItem
    {
        Hands hands;
        int attackValue;
        int attackModifier;
        int damageValue;
        int damageModifier;
        public Hands NumberHands
        {
            get { return hands; }
            protected set { hands = value; }
        }
        public int AttackValue
        {
            get { return attackValue; }
            protected set { attackValue = value; }
        }
        public int AttackModifier
        {
            get { return attackModifier; }
            protected set { attackModifier = value; }
        }
        public int DamageValue
        {
            get { return damageValue; }
            protected set { damageValue = value; }
        }

        public int DamageModifier
        {
            get { return damageModifier; }
            protected set { damageModifier = value; }
        }
        public Weapon
            (
            string name,
            string type,
            int price,
            float weight,
            Hands hand,
            int atk,
            int atkMod,
            int dmg,
            int dmgMod,
            params string[] allowClasses
            ) : base(name, type, price, weight, allowClasses)
        {
            NumberHands = hands;
            AttackValue = atk;
            AttackModifier = atkMod;
            DamageValue = dmg;
            DamageModifier = dmgMod;
        }
        public override object Clone()
        {
            string[] allowClasses = new string[allowableClasses.Count];
            for (int i = 0; i < allowableClasses.Count; i++)
                allowClasses[i] = allowableClasses[i];
            Weapon wp = new Weapon(
                Name,Type,Price,Weight,NumberHands,AttackValue,AttackModifier,DamageValue,DamageModifier,allowClasses
                );
            return wp;
        }
        public override string ToString()
        {
            string weaponString = base.ToString() + ", ";
            weaponString += NumberHands.ToString() + ", ";
            weaponString += AttackValue.ToString() + ", ";
            weaponString += AttackModifier.ToString() + ", ";
            weaponString += DamageValue.ToString() + ", ";
            weaponString += DamageModifier.ToString();

            foreach (string t in allowableClasses)
                weaponString += ", " + t;

            return weaponString;
        }
    }
}
