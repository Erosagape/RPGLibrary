using RpgLibrary.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.EffectClasses
{
    public enum EffectType { Damage, Heal }
    public abstract class BaseEffect
    {
        #region Field Region
        protected string name;
        #endregion
        #region Property Region
        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }
        #endregion

        #region Constructor Region
        protected BaseEffect()
        {
        }
        #endregion
        #region Method Region
        #endregion
        #region Virtual Method Region
        public abstract void Apply(Entity entity);
        #endregion
    }
}
