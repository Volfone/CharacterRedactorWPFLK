using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRedactorLK
{
    public class Warrior : Character
    {
        public static int MaxStr = 250;
        public static int MinStr = 30;
        public static int MaxDex = 70;
        public static int MinDex = 15;
        public static int MaxCon = 100;
        public static int MinCon = 20;
        public static int MaxInt = 50;
        public static int MinInt = 10;
        public Warrior(int strength, int dexterity, int constitution, int intelligence, string name) :
            base(MaxStr, MinStr, MaxDex, MinDex, MaxCon, MinCon, MaxInt, MinInt, name)
        {
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Constitution = constitution;
            this.Intelligence = intelligence;
            this.Attack += Strength * 5;
            this.Health += Strength * 2;
            this.Attack += Dexterity * 1;
            this.PDef += Dexterity * 1;
            this.Health += Constitution * 10;
            this.PDef += Constitution * 2;
            this.Mana += Intelligence * 1;
            this.MAttack += Intelligence * 1;
        }
        public Warrior(int strength, int dexterity, int constitution, int intelligence, string name, int level, int exp) :
            base(MaxStr, MinStr, MaxDex, MinDex, MaxCon, MinCon, MaxInt, MinInt, name, level, exp)
        {
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Constitution = constitution;
            this.Intelligence = intelligence;
            this.Attack += Strength * 5;
            this.Health += Strength * 2;
            this.Attack += Dexterity * 1;
            this.PDef += Dexterity * 1;
            this.Health += Constitution * 10;
            this.PDef += Constitution * 2;
            this.Mana += Intelligence * 1;
            this.MAttack += Intelligence * 1;
        }
        public Warrior(int strength, int dexterity, int constitution, int intelligence, string name, int cash, List<Item> items) :
            base(MaxStr, MinStr, MaxDex, MinDex, MaxCon, MinCon, MaxInt, MinInt, name, cash, items)
        {
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Constitution = constitution;
            this.Intelligence = intelligence;
            this.Attack += Strength * 5;
            this.Health += Strength * 2;
            this.Attack += Dexterity * 1;
            this.PDef += Dexterity * 1;
            this.Health += Constitution * 10;
            this.PDef += Constitution * 2;
            this.Mana += Intelligence * 1;
            this.MAttack += Intelligence * 1;
        }
        public Warrior(int strength, int dexterity, int constitution, int intelligence, string name, int cash, List<Item> items, int level, int exp) :
            base(MaxStr, MinStr, MaxDex, MinDex, MaxCon, MinCon, MaxInt, MinInt, name, cash, items, level, exp)
        {
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Constitution = constitution;
            this.Intelligence = intelligence;
            this.Attack += Strength * 5;
            this.Health += Strength * 2;
            this.Attack += Dexterity * 1;
            this.PDef += Dexterity * 1;
            this.Health += Constitution * 10;
            this.PDef += Constitution * 2;
            this.Mana += Intelligence * 1;
            this.MAttack += Intelligence * 1;
        }
        public Warrior(int strength, int dexterity, int constitution, int intelligence, string name, int cash,
            List<Item> items, List<Skill> skills, int acquiredSkillsAmount, int level, int exp) :
            base(MaxStr, MinStr, MaxDex, MinDex, MaxCon, MinCon, MaxInt, MinInt, name, cash, items, skills, acquiredSkillsAmount, level, exp)
        {
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Constitution = constitution;
            this.Intelligence = intelligence;
            this.Attack += Strength * 5;
            this.Health += Strength * 2;
            this.Attack += Dexterity * 1;
            this.PDef += Dexterity * 1;
            this.Health += Constitution * 10;
            this.PDef += Constitution * 2;
            this.Mana += Intelligence * 1;
            this.MAttack += Intelligence * 1;
        }
        public Warrior(int strength, int dexterity, int constitution, int intelligence, string name, int cash,
            List<Item> items, List<Item> equipment, List<Skill> skills, int acquiredSkillsAmount, int level, int exp) :
            base(MaxStr, MinStr, MaxDex, MinDex, MaxCon, MinCon, MaxInt, MinInt, name, cash, items, equipment, skills, acquiredSkillsAmount, level, exp)
        {
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Constitution = constitution;
            this.Intelligence = intelligence;
            this.Attack += Strength * 5;
            this.Health += Strength * 2;
            this.Attack += Dexterity * 1;
            this.PDef += Dexterity * 1;
            this.Health += Constitution * 10;
            this.PDef += Constitution * 2;
            this.Mana += Intelligence * 1;
            this.MAttack += Intelligence * 1;
        }

        public Warrior() : base(MaxStr, MinStr, MaxDex, MinDex, MaxCon, MinCon, MaxInt, MinInt, "Warrior") { }
    }
}
