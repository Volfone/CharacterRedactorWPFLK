using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRedactorLK
{
    public class Skill
    {
        public string Name { get; set; }
        public int Stats { get; set; }
        public Skill(string name, int stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public override string ToString()
        {
            return ($"\n\t{Name} - {Stats}");
        }
    }
}
