using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRedactorLK
{
    public class Rouge : Character
    {
        public static int MaxStr = 55;
        public static int MinStr = 15;
        public static int MaxDex = 250;
        public static int MinDex = 30;
        public static int MaxCon = 80;
        public static int MinCon = 20;
        public static int MaxInt = 70;
        public static int MinInt = 15;

        public Rouge(int strength, int dexterity, int constitution, int intelligence) :
            base(MaxStr, MinStr, MaxDex, MinDex, MaxCon, MinCon, MaxInt, MinInt, "Rouge")
        {
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Constitution = constitution;
            this.Intelligence = intelligence;
            this.Attack += Strength * 2;
            this.Health += Strength * 1;
            this.Attack += Dexterity * 4;
            this.PDef += Dexterity * 1.5;
            this.Health += Constitution * 6;
            this.Mana += Intelligence * 1.5;
            this.MAttack += Intelligence * 2;
        }
        public Rouge() : base(MaxStr, MinStr, MaxDex, MinDex, MaxCon, MinCon, MaxInt, MinInt, "Rouge") { }
    }
}
