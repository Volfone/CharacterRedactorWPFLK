using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRedactorLK
{
    public class Armor : Item
    {
        public static List<Item> ArmorList = new List<Item>()
        {
            {
                new Armor("Легка броня воина", 0, "Warrior", 20,
                new Dictionary<string, int>
                {
                    { "Strength", 30 },
                    { "Dexterity", 20 },
                    { "Constitution", 20 },
                    { "Intelligence", 20 }
                },
                new Dictionary<string, int>
                {
                    { "Attack", 0 },
                    { "Health", 50 },
                    { "PDef", 10 },
                    { "Mana", 0 },
                    { "MAttack", 0 }
                }
                )
            },
            {
                new Armor("Легка броня мага", 0, "Wizard", 20,
                new Dictionary<string, int>
                {
                    { "Strength", 20 },
                    { "Dexterity", 20 },
                    { "Constitution", 20 },
                    { "Intelligence", 30 }
                },
                new Dictionary<string, int>
                {
                    { "Attack", 0 },
                    { "Health", 20 },
                    { "PDef", 0 },
                    { "Mana", 20 },
                    { "MAttack", 10 }
                }
                )
            },
            {
                new Armor("Легка броня разбойника", 0, "Rogue", 20,
                new Dictionary<string, int>
                {
                    { "Strength", 20 },
                    { "Dexterity", 30 },
                    { "Constitution", 20 },
                    { "Intelligence", 20 }
                },
                new Dictionary<string, int>
                {
                    { "Attack", 10 },
                    { "Health", 20 },
                    { "PDef", 10 },
                    { "Mana", 0 },
                    { "MAttack", 0 }
                }
                )
            },
            {
                new Armor("Средняя броня воина", 1, "Warrior", 200,
                new Dictionary<string, int>
                {
                    { "Strength", 80 },
                    { "Dexterity", 30 },
                    { "Constitution", 30 },
                    { "Intelligence", 30 }
                },
                new Dictionary<string, int>
                {
                    { "Attack", 0 },
                    { "Health", 250 },
                    { "PDef", 50 },
                    { "Mana", 0 },
                    { "MAttack", 0 }
                }
                )
            },
            {
                new Armor("Средняя броня мага", 1, "Wizard", 200,
                new Dictionary<string, int>
                {
                    { "Strength", 30 },
                    { "Dexterity", 30 },
                    { "Constitution", 30 },
                    { "Intelligence", 80 }
                },
                new Dictionary<string, int>
                {
                    { "Attack", 0 },
                    { "Health", 100 },
                    { "PDef", 0 },
                    { "Mana", 200 },
                    { "MAttack", 50 }
                }
                )
            },
            {
                new Armor("Средняя броня разбойника", 1, "Rogue", 200,
                new Dictionary<string, int>
                {
                    { "Strength", 30 },
                    { "Dexterity", 80 },
                    { "Constitution", 30 },
                    { "Intelligence", 30 }
                },
                new Dictionary<string, int>
                {
                    { "Attack", 50 },
                    { "Health", 200 },
                    { "PDef", 50 },
                    { "Mana", 0 },
                    { "MAttack", 0 }
                }
                )
            },
            {
                new Armor("Тяжелая броня воина", 2, "Warrior", 500,
                new Dictionary<string, int>
                {
                    { "Strength", 200 },
                    { "Dexterity", 40 },
                    { "Constitution", 40 },
                    { "Intelligence", 40 }
                },
                new Dictionary<string, int>
                {
                    { "Attack", 0 },
                    { "Health", 500 },
                    { "PDef", 100 },
                    { "Mana", 0 },
                    { "MAttack", 0 }
                }
                )
            },
            {
                new Armor("Тяжелая броня мага", 2, "Wizard", 500,
                new Dictionary<string, int>
                {
                    { "Strength", 40 },
                    { "Dexterity", 40 },
                    { "Constitution", 40 },
                    { "Intelligence", 200 }
                },
                new Dictionary<string, int>
                {
                    { "Attack", 0 },
                    { "Health", 200 },
                    { "PDef", 0 },
                    { "Mana", 2000 },
                    { "MAttack", 100 }
                }
                )
            },
            {
                new Armor("Тяжелая броня разбойника", 2, "Rogue", 500,
                new Dictionary<string, int>
                {
                    { "Strength", 40 },
                    { "Dexterity", 200 },
                    { "Constitution", 40 },
                    { "Intelligence", 40 }
                },
                new Dictionary<string, int>
                {
                    { "Attack", 100 },
                    { "Health", 200 },
                    { "PDef", 150 },
                    { "Mana", 0 },
                    { "MAttack", 0 }
                }
                )
            }
        };
        public Armor(string name) : base(name)
        {
            Requirements = new Dictionary<string, int>
            {
                { "Strength", 0 },
                { "Dexterity", 0 },
                { "Constitution", 0 },
                { "Intelligence", 0 }
            };
            Stats = new Dictionary<string, int>
            {
                { "Attack", 0 },
                { "Health", 0 },
                { "PDef", 0 },
                { "Mana", 0 },
                { "MAttack", 0 }
            };
        }

        public Armor(string name, int quality, string clacc, int cost, Dictionary<string, int> requirements, Dictionary<string, int> stats) : base(name, quality, clacc, cost, requirements, stats)
        {

        }
    }
}
