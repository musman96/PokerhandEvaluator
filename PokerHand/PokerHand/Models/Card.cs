using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand.Models
{
    public class Card
    {
        public Rank Rank { get; set; }
        public SuiteEnum Suit { get; set; }
        public Card(Rank rank, SuiteEnum suit)
        {
            Rank = rank;
            Suit = suit;    
        }
    }
}
