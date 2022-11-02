using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRedactorLK
{
    public class Item
    {
        public string Name { get; set; }
        public string Quality { get; set; }
        public string Type { get; set; }
        public string Class { get; set; }
        public int Cost { get; set; }
        public Dictionary<string, int> Requirements;
        public Dictionary<string, int> Stats;
        private Dictionary<int, string> DictQuality = new Dictionary<int, string>
        {
            { 0, "Common" },
            { 1, "Rare" },
            { 2, "Epic" },
        };

        public Item(string name)
        {
            Name = name;
        }

        public Item(string name, int quality, string clacc, int cost, Dictionary<string, int> requirements, Dictionary<string, int> stats)
        {
            Name = name;
            Quality = DictQuality[quality];
            Class = clacc;
            Cost = cost;
            Requirements = requirements;
            Stats = stats;
            Type = this.GetType().Name;
        }

        public override string ToString()
        {
            return ($"\nName: {Name}\n"/* +
                $"Quality: {Quality}\n" +
                $"Type: {Type}\n" +
                $"Class: {Class}\n" +
                $"Cost : {Cost}\n" +
                $"Requirements:\n" +
                $"\tStrength: {Requirements["Strength"]}\n" +
                $"\tDexterity: {Requirements["Dexterity"]}\n" +
                $"\tConstitution: {Requirements["Constitution"]}\n" +
                $"\tIntelligence: {Requirements["Intelligence"]}\n" +
                $"Stats:\n" +
                $"\tAttack: {Stats["Attack"]}\n" +
                $"\tHealth: {Stats["Health"]}\n" +
                $"\tPDef: {Stats["PDef"]}\n" +
                $"\tMana: {Stats["Mana"]}\n" +
                $"\tMAttack: {Stats["MAttack"]}\n"*/);
        }
    }
}
