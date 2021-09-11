using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace RpgLibrary.CharacterClasses
{
    public class EntityDataManager
    {
        readonly Dictionary<string, EntityData> entityData = new Dictionary<string, EntityData>();
        public Dictionary<string,EntityData> EntityData
        {
            get { return entityData; }
        }
    }
}
