using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemsComapring.Models
{
    public class Item
    {
        public int Position { get; set; }
        public string Name { get; set; }
        public int Score { get; set; } = 0;
    }
}