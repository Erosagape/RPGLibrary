using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Key : BaseItem
    {
        #region Field Region

        #endregion
        #region Property Region
        #endregion
        #region Constructor Region
        public Key(string name,string type) :base(name,type,0,0,null)
        { 

        }
        #endregion
        #region Method Region
        #endregion
        #region Virtual Method region
        public override object Clone()
        {
            Key key = new Key(this.Name, this.Type);
            return key;
        }
        #endregion
    }
}
