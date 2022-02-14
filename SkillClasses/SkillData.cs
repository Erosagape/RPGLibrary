using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.SkillClasses
{
    public class SkillData
    {

        #region Field Region
        public string Name;
        public string PrimaryAttribute;
        public readonly Dictionary<string, int> ClassModifiers;
        #endregion
        #region Property Region
        #endregion
        #region Constructor Region
        public SkillData()
        {
            ClassModifiers = new Dictionary<string, int>();
        }
        #endregion
        #region Method Region
        #endregion
        #region Virtual Method region
        public override string ToString()
        {
            string toString = Name + ", ";
            toString += PrimaryAttribute;
            foreach(string s in ClassModifiers.Keys)
            {
                toString += ", " + s + "+" + ClassModifiers[s].ToString();
            }
            return toString;
        }
        #endregion

    }
}
