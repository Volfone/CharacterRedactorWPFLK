using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterRedactorLK
{
    [BsonKnownTypes(typeof(Rogue), typeof(Warrior), typeof(Wizard))]
    public class Character
    {
        public double Strength { get; set; }
        public double Dexterity { get; set; }
        public double Constitution { get; set; }
        public double Intelligence { get; set; }
        public double Attack { get; set; }
        public double Health { get; set; }
        public double PDef { get; set; }
        public double Mana { get; set; }
        public double MAttack { get; set; }
        public int Cash { get; set; }
        public int MaxStr { get; }
        public int MinStr { get; }
        public int MaxDex { get; }
        public int MinDex { get; }
        public int MaxCon { get; }
        public int MinCon { get; }
        public int MaxInt { get; }
        public int MinInt { get; }

        public string Name { get; set; }

        public List<Item> Items = new List<Item>();
        public List<Item> _equipment = new List<Item>();
        public List<Item> Equipment
        {
            get
            {
                return this._equipment;
            }
            set
            {
                foreach (Item item in value)
                {
                    this.Attack += item.Stats["Attack"];
                    this.Health += item.Stats["Health"];
                    this.PDef += item.Stats["PDef"];
                    this.Mana += item.Stats["Mana"];
                    this.MAttack += item.Stats["MAttack"];
                }
                this._equipment = value;
            }
        }
        public List<Skill> _skills = new List<Skill>();
        public List<Skill> Skills 
        {
            get
            {
                return this._skills;
            }
            set
            {
                string currentStat = "";
                string name = "";
                foreach (Skill item in value)
                {
                    name = item.Name;
                    currentStat = "" + name[0] + name[1];
                    switch (currentStat)
                    {
                        case "HP": this.Health += item.Stats;
                            break;
                        case "AT": this.Attack += item.Stats;
                            break;
                        case "PD": this.PDef += item.Stats;
                            break;
                        case "MP": this.Mana += item.Stats;
                            break;
                        default: break;
                    }
                }
                this._skills = value;
            }
        }

        public int AcquiredSkillsAmount { get; set; }

        public int _level { get; set; }
        public int _expirience { get; set; }


        public int Level
        {
            get
            {
                return this._level;
            }
            set
            {
                if (value > 0)
                {
                    this._level = value;
                    this.NeededExp = 0;
                    for (int i = 0; i <= this._level; i++)
                    {
                        this.NeededExp += i * 1000;
                    }
                }
            }
        }

        public int Expirience
        {
            get
            {
                return this._expirience;
            }
            set
            {
                this._expirience = value;
                while (this._expirience >= NeededExp)
                {
                    this._expirience -= NeededExp;
                    this.Level += 1;
                }
            }
        }

        public int NeededExp { get; set; }

        [BsonIgnoreIfDefault]
        [BsonId]
        ObjectId _id;
        public Character()
        {
        }

        public Character(int maxStr, int minStr, int maxDex, int minDex, int maxCon, int minCon, int maxInt, int minInt, string name)
        {
            this.MaxStr = maxStr;
            this.MinStr = minStr;
            this.MaxDex = maxDex;
            this.MinDex = minDex;
            this.MaxCon = maxCon;
            this.MinCon = minCon;
            this.MinInt = minInt;
            this.MaxInt = maxInt;
            this.Name = name;
            this.Cash = 500;
            this.Level = 1;
        }
        public Character(int maxStr, int minStr, int maxDex, int minDex, int maxCon, int minCon, int maxInt, int minInt, string name, int level, int exp)
        {
            this.MaxStr = maxStr;
            this.MinStr = minStr;
            this.MaxDex = maxDex;
            this.MinDex = minDex;
            this.MaxCon = maxCon;
            this.MinCon = minCon;
            this.MinInt = minInt;
            this.MaxInt = maxInt;
            this.Name = name;
            this.Cash = 500;
            this.Level = level;
            this.Expirience = exp;
        }

        public Character(int maxStr, int minStr, int maxDex, int minDex, int maxCon, int minCon, int maxInt, int minInt, string name, int cash, List<Item> items)
        {
            this.MaxStr = maxStr;
            this.MinStr = minStr;
            this.MaxDex = maxDex;
            this.MinDex = minDex;
            this.MaxCon = maxCon;
            this.MinCon = minCon;
            this.MinInt = minInt;
            this.MaxInt = maxInt;
            this.Name = name;
            this.Cash = cash;
            this.Items = items;
            this.Level = 1;
        }

        public Character(int maxStr, int minStr, int maxDex, int minDex, int maxCon, int minCon, int maxInt, int minInt,
            string name, int cash, List<Item> items, int level, int exp)
        {
            this.MaxStr = maxStr;
            this.MinStr = minStr;
            this.MaxDex = maxDex;
            this.MinDex = minDex;
            this.MaxCon = maxCon;
            this.MinCon = minCon;
            this.MinInt = minInt;
            this.MaxInt = maxInt;
            this.Name = name;
            this.Cash = cash;
            this.Items = items;
            this.Level = level;
            this.Expirience = exp;
        }

        public Character(int maxStr, int minStr, int maxDex, int minDex, int maxCon, int minCon, int maxInt, int minInt,
            string name, int cash, List<Item> items, List<Skill> skills, int acquiredSkillsAmount, int level, int exp)
        {
            this.MaxStr = maxStr;
            this.MinStr = minStr;
            this.MaxDex = maxDex;
            this.MinDex = minDex;
            this.MaxCon = maxCon;
            this.MinCon = minCon;
            this.MinInt = minInt;
            this.MaxInt = maxInt;
            this.Name = name;
            this.Cash = cash;
            this.Items = items;
            this.Skills = skills;
            this.AcquiredSkillsAmount = acquiredSkillsAmount;
            this.Level = level;
            this.Expirience = exp;
        }
        public Character(int maxStr, int minStr, int maxDex, int minDex, int maxCon, int minCon, int maxInt, int minInt,
            string name, int cash, List<Item> items, List<Item> equipment, List<Skill> skills, int acquiredSkillsAmount, int level, int exp)
        {
            this.MaxStr = maxStr;
            this.MinStr = minStr;
            this.MaxDex = maxDex;
            this.MinDex = minDex;
            this.MaxCon = maxCon;
            this.MinCon = minCon;
            this.MinInt = minInt;
            this.MaxInt = maxInt;
            this.Name = name;
            this.Cash = cash;
            this.Items = items;
            this.Equipment = equipment;
            this.Skills = skills;
            this.AcquiredSkillsAmount = acquiredSkillsAmount;
            this.Level = level;
            this.Expirience = exp;
        }

        public override string ToString()
        {
            string items = "";
            string equipments = "";
            string skills = "";
            foreach (Item item in this.Items)
            {
                items += item.ToString();
            }
            foreach (Item item in this.Equipment)
            {
                equipments += item.ToString();
            }
            foreach (Skill item in this.Skills)
            {
                skills += item.ToString();
            }
            return ($"{ this.Name}(lvl {this.Level}; exp {this.Expirience}/{this.NeededExp}): " +
                $"\nHealth - {this.Health}" +
                $"\nAttack - {this.Attack}" +
                $"\nPhisical defense - {this.PDef}" +
                $"\nMana - {this.Mana}" +
                $"\nMAttack - {this.MAttack}" +
                $"\n--------------------------------" +
                $"\nEquipment:{equipments}" +
                $"\n--------------------------------" +
                $"\nCash: {this.Cash}" +
                $"\nItems:{items}" +
                $"\n--------------------------------" +
                $"\nSkills:{skills}");
        }
    }
}
