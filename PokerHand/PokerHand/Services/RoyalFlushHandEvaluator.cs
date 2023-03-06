using PokerHand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand.Services
{
    public class RoyalFlushHandEvaluator : HandEvaluatorBase
    {
        public override bool IsValidHand(List<Card> cards)
        {
            return new StraightFlushHandEvaluator().IsValidHand(cards) && cards.Any(c => c.Rank == Rank.Ace) && cards.Any(c => c.Rank == Rank.King);
        }

        public override int GetHandRank(List<Card> cards)
        {
            return 9;
        }

        public override string GetHandReprentation()
        {
            return "Royal Flush";
        }
    }

}
