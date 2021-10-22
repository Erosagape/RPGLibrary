using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ChestData
    {

        #region Field Region
        public string Name;
        public string TextureName;
        public bool IsTrapped;
        public bool IsLocked;
        public string TrapName;
        public string KeyName;
        public int MinGold;
        public int MaxGold;
        public Dictionary<string, string> ItemCollection;
        #endregion
        #region Property Region
        #endregion
        #region Constructor Region
        public ChestData()
        {
            ItemCollection = new Dictionary<string, string>();
        }
        #endregion
        #region Method Region
        public override string ToString()
        {
            string toString = Name + ", ";
            toString += TextureName + ", ";
            toString += IsTrapped.ToString() + ", ";
            toString += IsLocked.ToString() + ", ";
            toString += TrapName + ", ";
            toString += KeyName + ", ";
            toString += MinGold.ToString() + ", ";
            toString += MaxGold.ToString();
            foreach(KeyValuePair<string,string> pair in ItemCollection)
            {
                toString += ", " + pair.Key + "+" + pair.Value;
            }
            return toString;
        }
        #endregion
        #region Virtual Method region
        #endregion

    }
}
