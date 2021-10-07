using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.CharacterClasses
{
    public class EntityData
    {
        public string EntityName;
        public int Strength;
        public int Dexterity;
        public int Cunning;
        public int WillPower;
        public int Magic;
        public int Constitution;
        public string HealthFormula;
        public string StaminaFormula;
        public string MagicFormula;
        private EntityData() { }
        public EntityData(
            string name,
            int str,
            int dex,
            int cun,
            int will,
            int mag,
            int cons,
            string hp,
            string sta,
            string mana
            )
        {
            EntityName = name;
            Strength = str;
            Dexterity = dex;
            Cunning = cun;
            WillPower = will;
            Magic = mag;
            Constitution = cons;
            HealthFormula = hp;
            StaminaFormula = sta;
            MagicFormula = mana;
        }
        public override string ToString()
        {
            string str =  EntityName + ", ";
            str += Strength.ToString() + ", ";
            str += Dexterity.ToString() + ", ";
            str += Cunning.ToString() + ", ";
            str += WillPower.ToString() + ", ";
            str += Magic.ToString() + ", ";
            str += Constitution.ToString() + ", ";
            str += HealthFormula.ToString() + ", ";
            str += StaminaFormula.ToString() + ", ";
            str += MagicFormula.ToString() + ", ";

            return str;
        }
        public object Clone()
        {
            EntityData en = new EntityData
            {
                EntityName = this.EntityName,
                Strength =this.Strength,
                Dexterity =this.Dexterity,
                Cunning =this.Cunning,
                WillPower=this.WillPower,
                Magic=this.Magic,
                Constitution=this.Constitution,
                HealthFormula =this.HealthFormula,
                StaminaFormula=this.StaminaFormula,
                MagicFormula=this.MagicFormula
            };
            return en;
        }
    }
}
