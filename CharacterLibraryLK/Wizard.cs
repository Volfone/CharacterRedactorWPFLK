using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRedactorLK
{
    public class Wizard : Character
    {
        public static int MaxStr = 45;
        public static int MinStr = 10;
        public static int MaxDex = 70;
        public static int MinDex = 30;
        public static int MaxCon = 60;
        public static int MinCon = 15;
        public static int MaxInt = 250;
        public static int MinInt = 35;
        public Wizard(int strength, int dexterity, int constitution, int intelligence) :
            base(MaxStr, MinStr, MaxDex, MinDex, MaxCon, MinCon, MaxInt, MinInt, "Wizard")
        {
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Constitution = constitution;
            this.Intelligence = intelligence;
            this.Attack += Strength * 3;
            this.Health += Strength * 1;
            this.PDef += Dexterity * 0.5;
            this.Health += Constitution * 3;
            this.PDef += Constitution * 1;
            this.Mana += Intelligence * 2;
            this.MAttack += Intelligence * 5;
        }
        public Wizard() : base(MaxStr, MinStr, MaxDex, MinDex, MaxCon, MinCon, MaxInt, MinInt, "Wizard") { }
    }
}
