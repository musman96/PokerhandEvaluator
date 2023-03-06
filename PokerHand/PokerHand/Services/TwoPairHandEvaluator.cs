using PokerHand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand.Services
{
    public class TwoPairHandEvaluator : HandEvaluatorBase
    {
        public override bool IsValidHand(List<Card> cards)
        {
            return cards.GroupBy(c => c.Rank).Count(g => g.Count() == 2) == 2;
        }

        public override int GetHandRank(List<Card> cards)
        {
            return 2;
        }
    }
}
