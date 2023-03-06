using PokerHand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand.Services
{
    public class StraightFlushHandEvaluator : HandEvaluatorBase
    {
        public override bool IsValidHand(List<Card> cards)
        {
            return new FlushHandEvaluator().IsValidHand(cards) && new StraightHandEvaluator().IsValidHand(cards);
        }

        public override int GetHandRank(List<Card> cards)
        {
            return 8;
        }

        public override string GetHandReprentation()
        {
            return "Straight Flush";
        }
    }
}
