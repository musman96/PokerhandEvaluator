using PokerHand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand.Services
{
    public class FlushHandEvaluator : HandEvaluatorBase
    {
        public override bool IsValidHand(List<Card> cards)
        {
            return cards.GroupBy(c => c.Suit).Count() == 1;
        }

        public override int GetHandRank(List<Card> cards)
        {
            return 5;
        }

        public override string GetHandReprentation()
        {
            return "Flush";
        }
    }
}
