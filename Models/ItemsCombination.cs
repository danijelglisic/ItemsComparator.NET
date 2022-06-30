using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemsComapring.Models
{
    public class ItemsCombination
    {
        public int Position1 { get; set; }
        public int Position2 { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }

        public ItemsCombination(int Position1, string Name1, int Score1, int Position2, string Name2, int Score2)
        {
            this.Position1 = Position1;
            this.Position2 = Position2;
            this.Name1 = Name1;
            this.Name2 = Name2;
            this.Score1 = Score1;
            this.Score2 = Score2;
        }
    }
}