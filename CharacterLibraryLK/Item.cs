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
        public int Amount { get; set; }

        public Item(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }

        public override string ToString()
        {
            return ($"\n\t{Name} - {Amount}");
        }
    }
}
