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
        public Warrior(int strength, int dexterity, int constitution, int intelligence) :
            base(MaxStr, MinStr, MaxDex, MinDex, MaxCon, MinCon, MaxInt, MinInt, "Warrior")
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
            this.MAH += Intelligence * 1;

        }
        public Warrior() : base(MaxStr, MinStr, MaxDex, MinDex, MaxCon, MinCon, MaxInt, MinInt, "Warrior") { }
    }
}
