using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ReagentData
    {

        #region Field Region
        public string Name;
        public string Type;
        public int Price;
        public float Weight;
        #endregion
        #region Property Region
        #endregion
        #region Constructor Region
        public ReagentData()
        {

        }
        #endregion
        #region Method Region
        public override string ToString()
        {
            string str = Name + ", ";
            str += Type + ", ";
            str += Price.ToString() + ", ";
            str += Weight.ToString();
            return str;
        }
        #endregion
        #region Virtual Method region
        #endregion

    }
}
