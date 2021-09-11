using System;
using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.CharacterClasses
{
    public enum EntityGender
    {
        Male,Female,NonBinary,Unknown
    }
    public enum EntityType
    {
        Character,NPC,Monster,Creature
    }

    public sealed class Entity
    {
        private string entityName;
        private string entityClass;
        private EntityType entityType;
        private EntityGender gender;
        public string EntityName { get { return entityName; } private set { entityName = value; } }
        public string EntityClass
        {
            get { return entityClass; }
            private set { entityClass = value; }
        }
        public EntityType EntityType { get { return entityType; } private set { entityType = value; } }
        public EntityGender Gender
        {
            get { return gender; }
            protected set { gender = value; }
        }
        private int strength;
        private int dexterity;
        private int cunning;
        private int willpower;
        private int magic;
        private int constitution;
        private int strengthModifier;
        private int dexterityModifier;
        private int cunningModifier;
        private int willpowerModifier;
        private int magicModifier;
        private int constitutionModifier;
        public int Strength
        {
            get { return strength + strengthModifier; }
            private set { strength = value; }
        }
        public int Dexterity
        {
            get { return dexterity + dexterityModifier; }
            private set { dexterity = value; }
        }
        public int Cunning
        {
            get { return cunning + cunningModifier; }
            private set { cunning = value; }
        }
        public int Willpower
        {
            get { return willpower + willpowerModifier; }
            private set { willpower = value; }
        }
        public int Magic
        {
            get { return magic + magicModifier; }
            private set { magic = value; }
        }
        public int Constitution
        {
            get { return constitution + constitutionModifier; }
            private set { constitution = value; }
        }
        private AttributePair health;
        private AttributePair stamina;
        private AttributePair mana;
        public AttributePair Health
        {
            get { return health; }
        }
        public AttributePair Stamina
        {
            get { return stamina; }
        }
        public AttributePair Mana
        {
            get { return mana; }
        }
        private int attack;
        private int damage;
        private int defense;
        private int level;
        private long experience;
        public int Level
        {
            get { return level; }
            private set { level = value; }
        }
        public long Experience
        {
            get { return experience; }
            private set { experience = value; }
        }
        private Entity()
        {
            Strength = 0;
            Dexterity = 0;
            Cunning = 0;
            Willpower = 0;
            Magic = 0;
            Constitution = 0;
            health = new AttributePair(0);
            stamina = new AttributePair(0);
            mana = new AttributePair(0);
        }
        public Entity(string name,EntityData data,EntityGender gen,EntityType typ)
        {
            EntityName = name;
            EntityClass = data.EntityName;
            Gender = gen;
            EntityType = typ;
            Strength = data.Strength;
            Dexterity = data.Dexterity;
            Cunning = data.Cunning;
            Willpower = data.WillPower;
            Magic = data.Magic;
            Constitution = data.Constitution;
            health = new AttributePair(0);
            stamina = new AttributePair(0);
            mana = new AttributePair(0);
        }
    }
}
