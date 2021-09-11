using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.CharacterClasses
{
    public class AttributePair
    {
        int currentValue;
        int maximumValue;
        public int CurrentValue
        {
            get { return currentValue; }
        }
        public int MaximumValue
        {
            get { return maximumValue; }
        }
        public static AttributePair Zero
        {
            get { return new AttributePair(); }
        }
        public AttributePair()
        {
            currentValue = 0;
            maximumValue = 0;
        }
        public AttributePair(int max)
        {
            currentValue = max;
            maximumValue = max;
        }
        public void Heal(ushort value)
        {
            currentValue += value;
            if (currentValue > maximumValue)
                currentValue = maximumValue;
        }
        public void Damage(ushort value)
        {
            currentValue -= value;
            if (currentValue < 0)
                currentValue = 0;
        }
        public void SetCurrent(int val)
        {
            currentValue = val;
            if (currentValue > maximumValue)
                currentValue = maximumValue;
        }
        public void SetMaximum(int val)
        {
            maximumValue = val;
            if (currentValue > maximumValue)
                currentValue = maximumValue;
        }
    }
}
