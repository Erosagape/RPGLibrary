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
            string str = "Name - " + EntityName + ", ";
            str += "Strength = " + Strength.ToString() + ", ";
            str += "Dexterity = " + Dexterity.ToString() + ", ";
            str += "Cunning = " + Cunning.ToString() + ", ";
            str += "Willpower = " + WillPower.ToString() + ", ";
            str += "Magic = " + Magic.ToString() + ", ";
            str += "Constitution = " + Constitution.ToString() + ", ";
            str += "Health Formula = " + HealthFormula.ToString() + ", ";
            str += "Stamina Formula = " + StaminaFormula.ToString() + ", ";
            str += "Magic Formula = " + MagicFormula.ToString() + ", ";

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
