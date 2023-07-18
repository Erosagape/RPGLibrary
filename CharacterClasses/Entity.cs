using System;
using System.Collections.Generic;
using System.Text;
using RpgLibrary.SkillClasses;
using RpgLibrary.SpellClasses;
using RpgLibrary.TalentClasses;
using RpgLibrary.EffectClasses;
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
            private set { gender = value; }
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
        readonly Dictionary<string, Skill> skills;
        public Dictionary<string,Skill> Skills
        {
            get { return skills; }
        }
        readonly List<Modifier> skillModifiers;
        public List<Modifier> SkillModifiers
        {
            get { return skillModifiers; }
        }
        readonly Dictionary<string, Spell> spells;
        public Dictionary<string, Spell> Spells
        {
            get { return spells; }
        }
        readonly List<Modifier> spellModifiers;
        public List<Modifier> SpellModifiers
        {
            get { return spellModifiers; }
        }
        readonly Dictionary<string, Talent> talents;
        public Dictionary<string, Talent> Talents
        {
            get { return talents; }
        }
        readonly List<Modifier> talentModifiers;
        public List<Modifier> TalentModifiers
        {
            get { return talentModifiers; }
        }
        #region Resistance and Weakness Field and Property Region
        private readonly List<Resistance> resistances;
        public List<Resistance> Resistances
        {
            get { return resistances; }
        }
        private readonly List<Weakness> weaknesses;
        public List<Weakness> Weaknesses
        {
            get { return weaknesses; }
        }
        #endregion

        private Entity()
        {
            Strength = 10;
            Dexterity = 10;
            Cunning = 10;
            Willpower = 10;
            Magic = 10;
            Constitution = 10;
            health = new AttributePair(0);
            stamina = new AttributePair(0);
            mana = new AttributePair(0);
            skills = new Dictionary<string, Skill>();
            spells = new Dictionary<string, Spell>();
            talents = new Dictionary<string, Talent>();
            skillModifiers = new List<Modifier>();
            spellModifiers = new List<Modifier>();
            talentModifiers = new List<Modifier>();
            resistances = new List<Resistance>();
            weaknesses = new List<Weakness>();
        }
        public Entity(
            string name,
            EntityData data,
            EntityGender gen,
            EntityType typ
            ) : this()
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
        public void Update(TimeSpan elapsedTime)
        {
            foreach (Modifier mod in skillModifiers)
                mod.Update(elapsedTime);
            foreach (Modifier mod in spellModifiers)
                mod.Update(elapsedTime);
            foreach (Modifier mod in talentModifiers)
                mod.Update(elapsedTime);
        }
    }
}
