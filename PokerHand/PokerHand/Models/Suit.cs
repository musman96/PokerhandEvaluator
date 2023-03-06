using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand.Models
{
    public class Suit
    {
        public string Name { get; set; }

        public Suit(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
