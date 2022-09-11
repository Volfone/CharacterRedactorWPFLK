using System;

namespace CharacterRedactorLK
{
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
        public double MAH { get; set; }

        public int MaxStr { get; }
        public int MinStr { get; }
        public int MaxDex { get; }
        public int MinDex { get; }
        public int MaxCon { get; }
        public int MinCon { get; }
        public int MaxInt { get; }
        public int MinInt { get; }

        public string Name { get; set; }

        public Character (int maxStr, int minStr, int maxDex, int minDex, int maxCon, int minCon, int maxInt, int minInt, string name)
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
        }
    }
}
